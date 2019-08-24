import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-exercise-type-chip',
  templateUrl: './exercise-type-chip.component.html',
  styleUrls: ['./exercise-type-chip.component.scss']
})
export class ExerciseTypeChipComponent implements OnInit {

  @Input() backgroundColor: string;
  @Input() color: string;
  @Input() show: boolean;
  @Input() value: string;


  constructor() { }

  ngOnInit() {
  }

}
