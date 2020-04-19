import { Component, OnInit } from '@angular/core';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-training-program-home',
  templateUrl: './training-program-home.component.html',
  styleUrls: ['./training-program-home.component.scss']
})
export class TrainingProgramHomeComponent implements OnInit {

  private _subs = new SubSink();

  constructor(
  ) { }

  ngOnInit(): void {
  }

}
