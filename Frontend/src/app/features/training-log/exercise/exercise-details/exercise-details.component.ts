import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedExercise } from 'src/ngrx/training-log/training/training.selectors';
import { Exercise } from 'src/server-models/entities/exercise.model';

@Component({
  selector: 'app-exercise-details',
  templateUrl: './exercise-details.component.html',
  styleUrls: ['./exercise-details.component.scss']
})
export class ExerciseDetailsComponent implements OnInit {

  protected exercise: Exercise;

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.store.select(selectedExercise).pipe(take(1))
      .subscribe(exercise => this.exercise = exercise);
  }

  get totalVolume() {
    return this.exercise.sets.reduce((total, set) => total + set.volume, 0);
  }

  get projectedMax() {
    return this.exercise.sets.reduce((max, set) => set.projectedMax > max ? set.projectedMax : max, 0);
  }
}
