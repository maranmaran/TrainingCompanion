import { Plan } from 'src/server-models/stripe/plan.model';
import { AppSettingsService } from './../../../../../business/services/shared/app-settings.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-plans',
  templateUrl: './plans.component.html',
  styleUrls: ['./plans.component.scss']
})
export class PlansComponent implements OnInit {

  @Input() plans: Plan[];
  colors: string[];
  @Output() subscribe = new EventEmitter<string>();
  
  constructor(private appSettings: AppSettingsService) { }

  ngOnInit() {
    this.colors = this.appSettings.planColors;
  }

  public onSubscribe(planId: string) {
    this.subscribe.emit(planId);
  }

}
