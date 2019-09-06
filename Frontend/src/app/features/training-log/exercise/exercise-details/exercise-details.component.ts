import { Component, OnInit } from '@angular/core';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { selectedExercise } from 'src/ngrx/training-log/training/training.selectors';
import { take } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';

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
}
