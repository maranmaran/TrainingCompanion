import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { ExportService } from 'src/business/services/feature-services/export.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExportEntities } from 'src/server-models/enums/export-entities.enum';
@Component({
  selector: 'app-export',
  templateUrl: './export.component.html',
  styleUrls: ['./export.component.scss']
})
export class ExportComponent implements OnInit {

  exportEntities = ExportEntities;
  selectedExportType: ExportEntities;

  constructor(
    private exportService: ExportService,
    private store: Store<AppState>,
  ) { }

  ngOnInit() {
  }

}
