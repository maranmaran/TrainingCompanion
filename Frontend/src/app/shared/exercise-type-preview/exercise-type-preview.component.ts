import { Component, OnInit, Input } from '@angular/core';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';

@Component({
  selector: 'app-exercise-type-preview',
  templateUrl: './exercise-type-preview.component.html',
  styleUrls: ['./exercise-type-preview.component.scss']
})
export class ExerciseTypePreviewComponent implements OnInit {

  @Input() exerciseType: ExerciseType;
  
  constructor() { }

  ngOnInit() {
  }

}
