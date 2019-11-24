import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedExercise } from 'src/ngrx/training-log/training/training.selectors';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { SubSink } from 'subsink';
import { UnitSystemService } from './../../../../../business/services/shared/unit-system.service';

@Component({
  selector: 'app-exercise-details',
  templateUrl: './exercise-details.component.html',
  styleUrls: ['./exercise-details.component.scss']
})
export class ExerciseDetailsComponent implements OnInit, OnDestroy {

  protected exercise: Exercise;
  private subs = new SubSink();

  constructor(
    private store: Store<AppState>,
    private unitService: UnitSystemService
  ) { }

  ngOnInit() {
    this.subs.add(
      this.store.select(selectedExercise)
        .subscribe(exercise => this.exercise = exercise)
      );
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  get totalVolume() {
    const volume = this.exercise.sets.reduce((total, set) => total + set.volume, 0);
    return this.unitService.transformWeight(volume);
  }

  get projectedMax() {
    const max = this.exercise.sets.reduce((max, set) => set.projectedMax > max ? set.projectedMax : max, 0);
    return this.unitService.transformWeight(max);
  }
}
