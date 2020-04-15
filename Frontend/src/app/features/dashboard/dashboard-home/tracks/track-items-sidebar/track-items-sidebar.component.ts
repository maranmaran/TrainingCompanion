import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { ChartConfiguration } from 'chart.js';
import { DashboardCards } from './../../../models/dashboard-cards';
import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { concatMap, filter, take } from 'rxjs/operators';
import { UIService } from 'src/business/services/shared/ui.service';
import { UISidenav, UISidenavAction } from 'src/business/shared/ui-sidenavs.enum';
import { setTrackEditMode } from 'src/ngrx/dashboard/dashboard.actions';
import { dashboardUpdated, tracks } from 'src/ngrx/dashboard/dashboard.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { Track } from 'src/server-models/entities/track.model';
import { mainDashboardComponents } from '../../../models/dashboard-cards';
import { getLineChartPreviewConfig } from './chart-preview-configurations/line-chart.preview-config';

@Component({
  selector: 'app-track-items-sidebar',
  templateUrl: './track-items-sidebar.component.html',
  styleUrls: ['./track-items-sidebar.component.scss']
})
export class TrackItemsSidebarComponent implements OnInit {

  dashboardCards = DashboardCards;
  mainDashboardComponents = mainDashboardComponents;

  @Output() dragEnter = new EventEmitter<any>()
  @Output() dragEnd = new EventEmitter()
  @Output() drop = new EventEmitter<{ event: CdkDragDrop<TrackItem[]>, trackIdx: number }>();

  @Output('saveTracks') saveTracksEvent = new EventEmitter<Track[]>();

  maxChartPreviewConfiguration: ChartConfiguration[];
  volumeChartPreviewConfiguration: ChartConfiguration[];

  constructor(
    private store: Store<AppState>,
    private UIService: UIService,
  ) { }

  ngOnInit(): void {
    this.store.select(activeTheme).pipe(take(1)).subscribe(theme => {
      this.volumeChartPreviewConfiguration = [getLineChartPreviewConfig(theme)]
    })
  }

  toggleSidenav = () => {

    setTimeout(() => this.store.dispatch(setTrackEditMode()), 500);

    this.UIService.doSidenavAction(UISidenav.DashboardComponents, UISidenavAction.Toggle);

    this.store.select(dashboardUpdated)
      .pipe(take(1), filter(updated => !!updated), concatMap(_ => this.store.select(tracks).pipe(take(1))))
      .subscribe(tracks => this.saveTracksEvent.emit(tracks))
  }


}
