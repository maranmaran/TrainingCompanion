import { Store } from '@ngrx/store';
import { Component, OnInit } from '@angular/core';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedPropertyType } from 'src/ngrx/exercise-property-type/exercise-property-type.selectors';
import { SubSink } from 'subsink';
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';

@Component({
  selector: 'app-exercise-properties-home',
  templateUrl: './exercise-properties-home.component.html',
  styleUrls: ['./exercise-properties-home.component.scss']
})
export class ExercisePropertiesHomeComponent implements OnInit {

  constructor(
  ) { }


  ngOnInit() {
  }

}
