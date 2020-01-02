import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { exerciseTypes } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';

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
    this.exerciseTypes$ = this.store.select(exerciseTypes).pipe(map(state => state.entities));
  }

}
