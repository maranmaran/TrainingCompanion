import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { concatMap, filter, take } from 'rxjs/operators';
import { UIService } from 'src/business/services/shared/ui.service';
import { UISidenav, UISidenavAction } from 'src/business/shared/ui-sidenavs.enum';
import { setTrackEditMode } from 'src/ngrx/dashboard/dashboard.actions';
import { dashboardUpdated, trackEditMode, tracks } from 'src/ngrx/dashboard/dashboard.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { Track } from 'src/server-models/entities/track.model';
import { mainDashboardComponents, sidebarCards } from '../../../models/dashboard-cards';

@Component({
  selector: 'app-track-items-sidebar',
  templateUrl: './track-items-sidebar.component.html',
  styleUrls: ['./track-items-sidebar.component.scss']
})
export class TrackItemsSidebarComponent implements OnInit {

  dashboardEditMode: Observable<boolean>;

  sidebarCards = sidebarCards;
  mainDashboardComponents = mainDashboardComponents;

  @Output() dragEnter = new EventEmitter<any>()
  @Output() dragEnd = new EventEmitter()
  @Output() drop = new EventEmitter<{event: CdkDragDrop<TrackItem[]>, trackIdx: number}>();

  @Output('saveTracks') saveTracksEvent = new EventEmitter<Track[]>();

  constructor(
    private store: Store<AppState>,
    private UIService: UIService,
  ) { }

  ngOnInit(): void {
    this.dashboardEditMode = this.store.select(trackEditMode);
  }

  toggleSidenav = () => {

    setTimeout(() => this.store.dispatch(setTrackEditMode()), 500);

    this.UIService.doSidenavAction(UISidenav.DashboardComponents, UISidenavAction.Toggle);

    this.store.select(dashboardUpdated)
    .pipe(take(1), filter(updated => !!updated), concatMap(_ => this.store.select(tracks).pipe(take(1))))
    .subscribe(tracks => this.saveTracksEvent.emit(tracks))
  }

}
