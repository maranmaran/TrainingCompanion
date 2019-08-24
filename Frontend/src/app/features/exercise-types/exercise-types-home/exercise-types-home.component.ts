import { Component, OnInit } from '@angular/core';
import { exerciseTypes } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-exercise-types-home',
  templateUrl: './exercise-types-home.component.html',
  styleUrls: ['./exercise-types-home.component.scss']
})
export class ExerciseTypesHomeComponent implements OnInit {

  protected exerciseTypes$: Observable<ExerciseType[]>;

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.exerciseTypes$ = this.store.select(exerciseTypes);
  }

}
