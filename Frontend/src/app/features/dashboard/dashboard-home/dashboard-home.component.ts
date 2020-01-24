import { CdkDragDrop, CdkDropList, moveItemInArray } from '@angular/cdk/drag-drop';
import { AfterViewInit, ChangeDetectorRef, Component, ComponentFactoryResolver, OnDestroy, OnInit, QueryList, Renderer2, ViewChild, ViewChildren } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Store } from '@ngrx/store';
import { Guid } from 'guid-typescript';
import { take } from 'rxjs/operators';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { UISidenav, UISidenavAction } from 'src/business/shared/ui-sidenavs.enum';
import { AppState } from 'src/ngrx/app/app.state';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';
import { SubSink } from 'subsink';
import { DashboardOutletDirective } from '../directives/dashboard-outlet.directive';
import { dashboardCards, DashboardCards } from '../models/dashboard-cards';
import { TrackItem } from '../models/track-item.model';
import { Track } from '../models/track.model';
import { DashboardService } from '../services/dashboard.service';
import { currentUserId } from './../../../../ngrx/auth/auth.selectors';
import { DashboardCardContainerComponent } from './dashboard-card-container/dashboard-card-container.component';

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styleUrls: ['./dashboard-home.component.scss']
})
export class DashboardHomeComponent implements OnInit, AfterViewInit, OnDestroy {

  @ViewChildren(DashboardOutletDirective) dashboardOutlets: QueryList<DashboardOutletDirective>;

  @ViewChildren('trackOne, trackTwo') dropLists: QueryList<CdkDropList>;

  private userId: string;
  tracks: Track[];

  dashboardEditMode = false;

  mainDashboardComponents: TrackItem[] = [
    { component: DashboardCards.Test, code: 'test', id: Guid.EMPTY, params: null },
    { component: DashboardCards.Test, code: 'test1', id: Guid.EMPTY, params: null }
  ]

  @ViewChild(MatSidenav, { static: true }) sidenav: MatSidenav;
  private _subs = new SubSink();

  constructor(
    private notificationService: NotificationSignalrService,
    private store: Store<AppState>,
    private cd: ChangeDetectorRef,
    private cfr: ComponentFactoryResolver,
    private dashboardService: DashboardService,
    private UIService: UIService,
    private renderer: Renderer2
  ) { }

  ngOnInit() {
    this.dashboardService.getUserTracks();

    this.store.select(currentUserId).pipe(take(1)).subscribe(userId => this.userId = userId);

    this.UIService.addOrUpdateSidenav(UISidenav.DashboardComponents, this.sidenav);

    this._subs.add(
      this.dashboardService.tracks$.subscribe(tracks => {
        this.tracks = tracks;
        this.cd.detectChanges();
        this.loadContents();
    }));
  }

  ngOnDestroy() {
    this._subs.unsubscribe();
  }

  ngAfterViewInit() {
    this.loadContents();
  }

  activateNotif() {
    this.notificationService.sendNotification(
      NotificationType.TrainingCreated,
      "Test notification " + Math.round(Math.random() * 10) + " from client",
      this.userId,
      this.userId);
  }

  loadContents = () => {
    if (!this.dashboardOutlets || !this.dashboardOutlets.length)
      return;

    this.dashboardOutlets.forEach(template => {
      this.cd.detectChanges();
      this.loadContent(template, template.item);
    });

    this.cd.detectChanges();
  }

  loadContent = (template: DashboardOutletDirective, item: TrackItem) => {
    if (!item.component)
      return;

    const viewContainerRef = template.viewContainerRef;
    viewContainerRef.clear();

    const factory = this.cfr.resolveComponentFactory(dashboardCards[item.component]);
    const componentRef = viewContainerRef.createComponent(factory);
    const instance = componentRef.instance as DashboardCardContainerComponent;
    instance.item = item;
  }

  toggleSidenav = () => {
    setTimeout(() => this.dashboardEditMode = !this.dashboardEditMode, this.UIService.isSidenavOpened(UISidenav.DashboardComponents) ? 0 : 500);
    this.UIService.doSidenavAction(UISidenav.DashboardComponents, UISidenavAction.Toggle);
  }

  drop(event: CdkDragDrop<TrackItem[]>, trackIdx: number) {

    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      const item = event.previousContainer.data[event.previousIndex];
      this.dashboardService.addItem(item, trackIdx);
      this.mainDashboardComponents.splice(this.mainDashboardComponents.indexOf(item), 1);
      // transferArrayItem(
      //   event.previousContainer.data,
      //   event.container.data,
      //   event.previousIndex,
      //   event.currentIndex);
    }
  }

  onSaveDashboard() {
    this.dashboardService.saveMainDashboard(this.tracks);
  }

  dragEnter(event: any) {
    const droplist = event.container;
    const draggedItem = event.item;

    this.dropLists.filter(list => list.id != droplist.id).forEach(droplist => {
      this.renderer.removeClass(droplist.element.nativeElement, 'highlight')
    });

    this.dropLists.filter(list => list.id == droplist.id).forEach(droplist => {
      this.renderer.addClass(droplist.element.nativeElement, 'highlight')
    });
  }

  dragEnd() {
    this.dropLists.filter(list => list.element.nativeElement.classList.contains('highlight')).forEach(droplist => {
      this.renderer.removeClass(droplist.element.nativeElement, 'highlight')
    });
  }

}
