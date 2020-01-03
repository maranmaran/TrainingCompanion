import { ComponentPortal } from '@angular/cdk/portal';
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/app/app.state';
import { UIService } from './../../../../../business/services/shared/ui.service';
import { ImportEntities } from './../../../../../server-models/enums/import-entities.enum';
import { MediaUploaderComponent } from './../../../media/media-uploader/media-uploader.component';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.scss']
})
export class ImportComponent implements OnInit {

  importEntities = ImportEntities;
  selectedImportType: ImportEntities;
  fileTypesToAccept = '.csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel';

  _uploadInputComponent: ComponentPortal<MediaUploaderComponent>;

  constructor(
    private store: Store<AppState>,
    private UIService: UIService,
  ) { }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
      this._uploadInputComponent = new ComponentPortal(MediaUploaderComponent);
  }


}
