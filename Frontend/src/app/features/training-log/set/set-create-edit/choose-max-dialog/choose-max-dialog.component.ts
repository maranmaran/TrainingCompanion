import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { PersonalBestService } from 'src/business/services/feature-services/personal-best.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { PersonalBest } from './../../../../../../server-models/entities/personal-best.model';

@Component({
  selector: 'app-choose-max-dialog',
  templateUrl: './choose-max-dialog.component.html',
  styleUrls: ['./choose-max-dialog.component.scss']
})
export class ChooseMaxDialogComponent implements OnInit {

  constructor(
    private prService: PersonalBestService,
    private store: Store<AppState>,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, systemPR: PersonalBest }) { }

  ngOnInit(): void {
    console.log(this.data.systemPR);
  }

}
