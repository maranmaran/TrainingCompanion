import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-exercise-type-chip',
  templateUrl: './exercise-type-chip.component.html',
})
export class ExerciseTypeChipComponent implements OnInit {

  @Input() backgroundColor: string;
  @Input() color: string;
  @Input() show = true;
  @Input() groupActive = true;
  @Input() value = 'Tag';
  @Input() showInactiveGroups = true;
  @Input() showInactiveTags = true;
  @Input() disableAll = false;


  constructor() { }

  ngOnInit() {
  }

}
