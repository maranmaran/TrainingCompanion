import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { ExportService } from 'src/business/services/feature-services/export.service';
import { AppState } from 'src/ngrx/app/app.state';
import { UIService } from './../../../../../business/services/shared/ui.service';

@Component({
  selector: 'app-export',
  templateUrl: './export.component.html',
  styleUrls: ['./export.component.scss']
})
export class ExportComponent implements OnInit {

  constructor(
    private exportService: ExportService,
    private store: Store<AppState>,
    private UIService: UIService,
  ) { }

  ngOnInit() {
  }

}
