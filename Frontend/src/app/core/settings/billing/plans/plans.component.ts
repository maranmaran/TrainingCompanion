import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Plan } from 'src/server-models/stripe/plan.model';

@Component({
  selector: 'app-plans',
  templateUrl: './plans.component.html',
  styleUrls: ['./plans.component.scss']
})
export class PlansComponent implements OnInit {

  @Input() plans: Plan[];
  @Output() subscribe = new EventEmitter<string>();

  constructor() { }

  ngOnInit() {
  }

  public onSubscribe(planId: string) {
    this.subscribe.emit(planId);
  }

}
