import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/app/app.state';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { ImportResponse } from 'src/server-models/cqrs/import/response/import.response';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-import-button',
  templateUrl: './import-button.component.html',
  styleUrls: ['./import-button.component.scss']
})
export class ImportButtonComponent implements OnInit {

  @Input() fileTypesToAccept: string = '.csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel';
  @Input() importFn: (file: File, userId: string) => void;
  @Input() isUploading: Observable<{uploading: boolean, response: ImportResponse}>;

  @ViewChild('uploadInput', {static: false}) uploadInput: ElementRef;

  _userId: string;

  _subs = new SubSink();

  constructor(
    private store: Store<AppState>,
  ) { }

  ngOnInit() {
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this._userId = id);
  }

  triggerUploadMediaInput() {
    this.uploadInput.nativeElement.click();
  }

  uploadMedia(files: FileList) {
    if(files.item(0)) {
      this.onImport(files.item(0));
      this.uploadInput.nativeElement.value = '';
    }
  }

  onImport(file: File) {
    this.importFn(file, this._userId);
  }
}
