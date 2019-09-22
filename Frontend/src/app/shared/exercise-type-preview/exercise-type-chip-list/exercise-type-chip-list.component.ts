import { Component, OnInit, Input } from '@angular/core';
import { Tag } from 'src/server-models/entities/tag.model';

@Component({
  selector: 'app-exercise-type-chip-list',
  templateUrl: './exercise-type-chip-list.component.html',
  styleUrls: ['./exercise-type-chip-list.component.scss']
})
export class ExerciseTypeChipListComponent implements OnInit {

  @Input() propertyList: Tag[];

  constructor() { }

  ngOnInit() {
  }

}
