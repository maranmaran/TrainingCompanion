import { Component, Input, OnInit } from '@angular/core';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';

@Component({
  selector: 'app-basic-details',
  templateUrl: './basic-details.component.html',
  styleUrls: ['./basic-details.component.scss']
})
export class BasicDetailsComponent implements OnInit {

  @Input() trainingProgram: TrainingProgram;

  constructor() { }

  ngOnInit(): void {
  }

}
