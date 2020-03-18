import { CdkDragDrop, CdkDropList } from '@angular/cdk/drag-drop';
import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnDestroy, OnInit, QueryList, Renderer2, ViewChild, ViewChildren } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Store } from '@ngrx/store';
import { AttributesMap } from 'ng-dynamic-component';
import { Observable } from 'rxjs';
import { catchError, take } from 'rxjs/operators';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { UISidenav, UISidenavAction } from 'src/business/shared/ui-sidenavs.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';
import { SubSink } from 'subsink';
import { TrackItem } from '../../../../server-models/entities/track-item.model';
import { Track } from '../../../../server-models/entities/track.model';
import { DashboardOutletDirective } from '../directives/dashboard-outlet.directive';
import { Activity } from '../models/activity.model';
import { dashboardCards, mainDashboardComponents } from '../models/dashboard-cards';
import { TracksService } from '../services/tracks.service';
import { currentUserId } from './../../../../ngrx/auth/auth.selectors';
import { sidebarCards } from './../models/dashboard-cards';
import { DashboardService } from './../services/dashboard.service';

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styleUrls: ['./dashboard-home.component.scss'],
})
export class DashboardHomeComponent implements OnInit, OnDestroy {

  @ViewChildren(DashboardOutletDirective) dashboardOutlets: QueryList<DashboardOutletDirective>;
  @ViewChildren('trackOne, trackTwo') dropLists: QueryList<CdkDropList>;

  activities: Observable<Activity[]>;

  private userId: string;

  dashboardEditMode = false;
  dashboardUpdated = false;

  sidebarCards = sidebarCards;
  dashboardCards = dashboardCards;
  mainDashboardComponents = mainDashboardComponents;

  tracks: Track[];
  attrs: AttributesMap;
  //TODO: Directives in ndcDynamic have trouble with angular AOT - see issue on their github
  // dirs: DynamicDirectiveDef<any>[];

  @ViewChild(MatSidenav, { static: true }) sidenav: MatSidenav;
  private _subs = new SubSink();

  constructor(
    @Inject(DOCUMENT) private document,
    private notificationService: NotificationSignalrService,
    private store: Store<AppState>,
    private dashboardService: DashboardService,
    private tracksService: TracksService,
    private UIService: UIService,
    private renderer: Renderer2
  ) {
  }

  ngOnInit() {
    // this.document.getElementById('dashboard-sidenav-content').style.setProperty("overflow-y", "hidden", "important")
    this.store.select(currentUserId).pipe(take(1)).subscribe(userId => this.userId = userId);
    this.UIService.addOrUpdateSidenav(UISidenav.DashboardComponents, this.sidenav);

    this.dashboardService.getUserTracks();
    this.attrs = this.tracksService.trackItemAttributes;
    // this.dirs = this.dashboardService.trackItemDirectives;

    this.activities = this.dashboardService.getFeed(this.userId).pipe(catchError(err => []));

    this._subs.add(
      this.tracksService.tracks$.subscribe(tracks => {
        this.tracks = tracks;
      }));
  }

  ngOnDestroy() {
    // this.document.getElementById('dashboard-sidenav-content').style.setProperty("overflow-y", "auto", "important")

    this._subs.unsubscribe();
  }

  activateNotif() {
    this.notificationService.sendNotification(
      NotificationType.TrainingCreated,
      "Test notification " + Math.round(Math.random() * 10) + " from client",
      this.userId,
      this.userId);
  }

  toggleSidenav = () => {
    setTimeout(() => this.dashboardEditMode = !this.dashboardEditMode, this.UIService.isSidenavOpened(UISidenav.DashboardComponents) ? 0 : 500);
    this.UIService.doSidenavAction(UISidenav.DashboardComponents, UISidenavAction.Toggle);
  }

  drop(event: CdkDragDrop<TrackItem[]>, trackIdx: number = null) {
    if (event.previousContainer != event.container) {
      this.dashboardUpdated = true;
      const item = event.previousContainer.data[event.previousIndex];
      this.tracksService.addItem(item, trackIdx);
    }
  }

  onSaveDashboard() {
    if (this.dashboardUpdated) {
      this.dashboardService.saveMainDashboard(this.tracks);
    }
  }

  dragEnter(event: any) {
    const droplist = event.container;

    this.dropLists.filter(list => list.id != droplist.id).forEach(droplist => {
      this.renderer.removeClass(droplist.element.nativeElement, 'theme-hover-background')
    });

    this.dropLists.filter(list => list.id == droplist.id).forEach(droplist => {
      this.renderer.addClass(droplist.element.nativeElement, 'theme-hover-background')
    });
  }

  dragEnd(event) {
    this.dropLists.filter(list => list.element.nativeElement.classList.contains('theme-hover-background')).forEach(droplist => {
      this.renderer.removeClass(droplist.element.nativeElement, 'theme-hover-background')
    });
  }

}
