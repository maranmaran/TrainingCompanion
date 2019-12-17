import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-training-details-data',
  templateUrl: './training-details-data.component.html',
  styleUrls: ['./training-details-data.component.scss']
})
export class TrainingDetailsDataComponent implements OnInit {

  @Input() data: any;

  constructor() { }

  ngOnInit() {
  }

}
