import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { map } from 'rxjs/operators';
import { transformWeight } from 'src/business/services/shared/unit-system.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { sessionNumberOfLifts, sessionVolume } from 'src/ngrx/training-log/training.selectors';
import { unitSystem } from './../../../../../../ngrx/auth/auth.selectors';

@Component({
  selector: 'app-training-details-data',
  templateUrl: './training-details-data.component.html',
  styleUrls: ['./training-details-data.component.scss']
})
export class TrainingDetailsDataComponent implements OnInit {

  data: Observable<{ volume: string; numOfLifts: number }>

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.data = combineLatest(
      this.store.select(unitSystem),
      this.store.select(sessionVolume),
      this.store.select(sessionNumberOfLifts),
    ).pipe(
      map(([system, volume, numOfLifts]) => ( { volume: transformWeight(volume, system), numOfLifts} ) )
    )
  }

}
