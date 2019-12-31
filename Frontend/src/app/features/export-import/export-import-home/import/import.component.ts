import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { ImportService } from 'src/business/services/feature-services/import.service';
import { AppState } from 'src/ngrx/app/app.state';
import { UIService } from './../../../../../business/services/shared/ui.service';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.scss']
})
export class ImportComponent implements OnInit {

  constructor(
    private importService: ImportService,
    private store: Store<AppState>,
    private UIService: UIService,
  ) { }

  ngOnInit() {
  }

}
