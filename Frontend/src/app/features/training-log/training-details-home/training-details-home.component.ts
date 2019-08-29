import { Component, OnInit, Input } from '@angular/core';
import { Training } from 'src/server-models/entities/training.model';

@Component({
  selector: 'app-training-details-home',
  templateUrl: './training-details-home.component.html',
  styleUrls: ['./training-details-home.component.scss']
})
export class TrainingDetailsHomeComponent implements OnInit {

  @Input() training: Training;
  
  constructor() { }

  ngOnInit() {
  }

}
