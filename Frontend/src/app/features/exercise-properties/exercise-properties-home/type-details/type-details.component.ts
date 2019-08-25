import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedPropertyType } from 'src/ngrx/exercise-property-type/exercise-property-type.selectors';

@Component({
  selector: 'app-type-details',
  templateUrl: './type-details.component.html',
  styleUrls: ['./type-details.component.scss']
})
export class TypeDetailsComponent implements OnInit {

  exercisePropertyType$: Observable<ExercisePropertyType>

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.exercisePropertyType$ = this.store.select(selectedPropertyType);
  }


}
