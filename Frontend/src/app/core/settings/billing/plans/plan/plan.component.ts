import { Plan } from 'src/server-models/stripe/plan.model';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';


@Component({
  selector: 'app-plan',
  templateUrl: './plan.component.html',
  styleUrls: ['./plan.component.scss']
})
export class PlanComponent implements OnInit {

  @Input() plan: Plan;
  @Input() colorIndex: number;
  @Output() subscribe = new EventEmitter<string>();
  @Input() showSubscribeButton = true;

  constructor() { }

  ngOnInit() {
  }

}
