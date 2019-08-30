import { Component, OnInit, Input } from '@angular/core';
import { Exercise } from 'src/server-models/entities/exercise.model';

@Component({
  selector: 'app-exercise-details',
  templateUrl: './exercise-details.component.html',
  styleUrls: ['./exercise-details.component.scss']
})
export class ExerciseDetailsComponent implements OnInit {

  @Input() exercise: Exercise;
  
  constructor() { }

  ngOnInit() {
  }

}
