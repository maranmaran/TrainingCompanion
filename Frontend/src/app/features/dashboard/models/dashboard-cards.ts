import { Guid } from 'guid-typescript';
import { TrackItem } from '../../../../server-models/entities/track-item.model';
import { VolumeCardComponent } from './../dashboard-home/track-items-sidebar/card-components/volume-card/volume-card.component';

export enum DashboardCards {
  Volume = 'Volume',
}

export const dashboardCards = {
  Volume: VolumeCardComponent,
}

export const sidebarCards = {
  Volume: `
          <h4>Track exercises volume: </h4>
          <i class="fas fa-chart-pie fa-5x row-center additional-padding"></i>
        `,
}

export const mainDashboardComponents: TrackItem[] = [
  { component: DashboardCards.Volume, code: 'dashboard-volume', id: Guid.EMPTY, params: null },
]
