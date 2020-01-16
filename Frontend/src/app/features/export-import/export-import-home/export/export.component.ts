import { Component, OnInit } from '@angular/core';
import { ExportEntities } from 'src/server-models/enums/export-entities.enum';
import { ExportService } from 'src/business/services/feature-services/export.service';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/app/app.state';

@Component({
  selector: 'app-export',
  templateUrl: './export.component.html',
  styleUrls: ['./export.component.scss']
})
export class ExportComponent implements OnInit {
  
  exportEntities = ExportEntities;
  selectedIExportType: ExportEntities;

  constructor(
    private exportService: ExportService,
    private store: Store<AppState>,
  ) { }

  ngOnInit() {
  }

}
