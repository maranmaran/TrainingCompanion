import { Component, OnInit, Input } from '@angular/core';
import { ExerciseProperty } from 'src/server-models/entities/exercise-property.model';

@Component({
  selector: 'app-exercise-type-chip-list',
  templateUrl: './exercise-type-chip-list.component.html',
  styleUrls: ['./exercise-type-chip-list.component.scss']
})
export class ExerciseTypeChipListComponent implements OnInit {

  @Input() propertyList: ExerciseProperty[];
  
  constructor() { }

  ngOnInit() {
  }

}
