import { Component, Input, OnInit } from '@angular/core';
import { TrackItem } from '../../../../../server-models/entities/track-item.model';

@Component({
  selector: 'app-dashboard-card-container',
  templateUrl: './dashboard-card-container.component.html',
  styleUrls: ['./dashboard-card-container.component.scss']
})
export class DashboardCardContainerComponent implements OnInit {

  @Input() item: TrackItem;

  constructor() { }

  ngOnInit() {
  }

}
