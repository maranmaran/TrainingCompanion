import { trainingBlockDays } from './../../../../../ngrx/training-program/training-block-day/training-block-day.selectors';
import { TrainingBlockDayService } from './../../../../../business/services/feature-services/training-block-day.service';
import { selectedTrainingBlock, selectedTrainingBlockId } from './../../../../../ngrx/training-program/training-block/training-block.selectors';
import { SubSink } from 'subsink';
import { AppState } from './../../../../../ngrx/global-setup.ngrx';
import { Store } from '@ngrx/store';
import { TrainingBlock, TrainingBlockDay } from './../../../../../server-models/entities/training-program.model';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { of } from 'rxjs';
import { take, toArray, filter, switchMap } from 'rxjs/operators';
import { trainingBlockDayFetched } from 'src/ngrx/training-program/training-block-day/training-block-day.actions';
import * as _ from 'lodash';

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
        do {
          let week = days.slice(current, current + 7);
          weeks.push(week);
          current += 7;
        } while (current <= days.length)

        this.weeks = weeks;
      }
    )
  }

}
