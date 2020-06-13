import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import * as _ from 'lodash';
import { SubSink } from 'subsink';
import { TrainingBlockDayService } from './../../../../../business/services/feature-services/training-block-day.service';
import { AppState } from './../../../../../ngrx/global-setup.ngrx';
import { trainingBlockDays } from './../../../../../ngrx/training-program/training-block-day/training-block-day.selectors';
import { TrainingBlockDay } from './../../../../../server-models/entities/training-program.model';

@Component({
  selector: 'app-workout-filler',
  templateUrl: './workout-filler.component.html',
  styleUrls: ['./workout-filler.component.scss']
})
export class WorkoutFillerComponent implements OnInit, OnDestroy {

  // days: number;
  weeks = [];

  private _subs = new SubSink();

  constructor(
    private store: Store<AppState>,
    private dayService: TrainingBlockDayService
  ) { }

  ngOnInit() {
    this._subs.add(
      this.onDaysFetched()
    )
  }

  ngOnDestroy(): void {
    this._subs.unsubscribe();
  }

  dayId = (day: TrainingBlockDay) => day.id;

  onDaysFetched() {
    return this.store.select(trainingBlockDays).subscribe(
      (days: TrainingBlockDay[]) => {

        days = _.cloneDeep(days);

        if (days.length == 0) return this.weeks = [];

        let weeks = [];
        let current = 0;
        while (current < days.length) {
          let week = days.slice(current, current + 7);
          weeks.push(week);
          current += 7;
        }

        this.weeks = weeks;
      }
    )
  }

}
