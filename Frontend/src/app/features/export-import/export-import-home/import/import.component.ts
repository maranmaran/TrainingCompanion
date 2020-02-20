import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { UIService } from './../../../../../business/services/shared/ui.service';
import { ImportEntities } from './../../../../../server-models/enums/import-entities.enum';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.scss']
})
export class ImportComponent implements OnInit {

  importEntities = ImportEntities;
  selectedImportType: ImportEntities;

  constructor(
    private store: Store<AppState>,
    private UIService: UIService,
  ) { }

  ngOnInit() {
  }

}
