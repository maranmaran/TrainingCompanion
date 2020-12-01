import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Guid } from 'guid-typescript';
import * as _ from 'lodash-es';
import { SubSink } from 'subsink';
import { TrainingBlockDayService } from './../../../../../business/services/feature-services/training-block-day.service';
import { AppState } from './../../../../../ngrx/global-setup.ngrx';
import { trainingBlockDays } from './../../../../../ngrx/training-program/training-block-day/training-block-day.selectors';
import { TrainingBlockDay } from './../../../../../server-models/entities/training-program.model';

export interface TrainingBlockWeek {
  id: string;
  days: TrainingBlockDay[];
}

@Component({
  selector: 'app-workout-filler',
  templateUrl: './workout-filler.component.html',
  styleUrls: ['./workout-filler.component.scss']
})
export class WorkoutFillerComponent implements OnInit, OnDestroy {

  // days: number;
  weeks: TrainingBlockWeek[] = [];

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

  trackDayId = (day: TrainingBlockDay) => day.id;
  trackWeekId = (week: TrainingBlockDay) => week.id;


  onDaysFetched() {
    return this.store.select(trainingBlockDays).subscribe(
      (days: TrainingBlockDay[]) => {

        console.log('New days ', days);

        days = _.cloneDeep(days);

        if (days.length == 0) return this.weeks = [];

        if(this.weeks = []) {
          this.createWeeks(days);
        } else {
          this.updateWeeks(days);
        }
      }
    )
  }

  updateWeeks(days: TrainingBlockDay[]) {
    this.weeks.forEach((week, weekIdx) => {
      week.days.forEach((day, dayIdx) => {
        day = days[weekIdx * 7 + dayIdx];
      });
    })
  }

  createWeeks(days: TrainingBlockDay[]) {
    let weeks = [];
    let current = 0;

    while (current < days.length) {
      
      let week: TrainingBlockWeek = { 
        id: Guid.create().toString(), 
        days: days.slice(current, current + 7) 
      };

      weeks.push(week);
      current += 7;
    }

    this.weeks = weeks;
  }

}
