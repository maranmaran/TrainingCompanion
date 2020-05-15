import { Component, OnInit, Input } from '@angular/core';
import { Training } from 'src/server-models/entities/training.model';

@Component({
  selector: 'app-block-training',
  templateUrl: './block-training.component.html',
  styleUrls: ['./block-training.component.scss']
})
export class BlockTrainingComponent implements OnInit {

  @Input() training: Training;

  constructor() { }

  ngOnInit(): void {
  }

  onAdd(training: Training) {
    // add exercise
  }

}
