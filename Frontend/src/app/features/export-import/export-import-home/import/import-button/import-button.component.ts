import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'app-import-button',
  templateUrl: './import-button.component.html',
  styleUrls: ['./import-button.component.scss']
})
export class ImportButtonComponent implements OnInit {

  @Input() fileTypesToAccept: string = '.csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel';
  @Output() fileUploaded = new EventEmitter<File>();

  @ViewChild('uploadInput', {static: false}) uploadInput: ElementRef;

  constructor(
  ) { }

  ngOnInit() {  }

  triggerUploadMediaInput() {
    this.uploadInput.nativeElement.click();
  }

  uploadMedia(files: FileList) {
    if(files.item(0)) {
      this.fileUploaded.emit(files.item(0));
      this.uploadInput.nativeElement.value = '';
    }
  }
}
