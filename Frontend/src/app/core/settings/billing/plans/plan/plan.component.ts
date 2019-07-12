import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Plan } from 'src/server-models/stripe/plan.model';

@Component({
  selector: 'app-plan',
  templateUrl: './plan.component.html',
  styleUrls: ['./plan.component.scss']
})
export class PlanComponent implements OnInit {

  @Input() plan: Plan;
  @Input() color: string;
  @Output() subscribe = new EventEmitter<string>();
  @Input() showSubscribeButton = true;

  constructor() { }

  ngOnInit() {
  }

}
