import { Component, OnInit, Input } from '@angular/core';
import { DashboardItem } from '../../models/dashboard-item.interface';

@Component({
  selector: 'app-dashboard-card-container',
  templateUrl: './dashboard-card-container.component.html',
  styleUrls: ['./dashboard-card-container.component.scss']
})
export class DashboardCardContainerComponent implements OnInit {

  @Input() item: DashboardItem;
  
  constructor() { }

  ngOnInit() {
  }

}
