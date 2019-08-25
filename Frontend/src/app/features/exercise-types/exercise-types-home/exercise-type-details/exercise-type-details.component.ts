import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedExerciseType } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-exercise-type-details',
  templateUrl: './exercise-type-details.component.html',
  styleUrls: ['./exercise-type-details.component.scss']
})
export class ExerciseTypeDetailsComponent implements OnInit {

  exerciseType$: Observable<ExerciseType>

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.exerciseType$ = this.store.select(selectedExerciseType);
  }

}
