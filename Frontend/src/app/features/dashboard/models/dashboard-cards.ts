import { Guid } from 'guid-typescript';
import { TrackItem } from '../../../../server-models/entities/track-item.model';
import { VolumeCardComponent } from '../dashboard-home/tracks/card-components/volume-card/volume-card.component';

export enum DashboardCards {
  Volume = 'Volume',
  Max = 'Max',
}

export const dashboardCards = {
  Volume: VolumeCardComponent,
}

export const mainDashboardComponents: TrackItem[] = [
  { component: DashboardCards.Volume, code: 'dashboard-volume', id: Guid.EMPTY, jsonParams: null },
  { component: DashboardCards.Max, code: 'dashboard-max', id: Guid.EMPTY, jsonParams: null },
]
