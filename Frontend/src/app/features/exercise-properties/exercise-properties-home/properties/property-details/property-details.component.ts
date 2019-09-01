import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { Component, OnInit } from '@angular/core';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';
import { selectedExerciseProperty } from 'src/ngrx/exercise-property-type/exercise-property-type.selectors';

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html',
  styleUrls: ['./property-details.component.scss']
})
export class PropertyDetailsComponent implements OnInit {

  exerciseProperty$: Observable<ExerciseProperty>

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.exerciseProperty$ = this.store.select(selectedExerciseProperty);
  }

}
