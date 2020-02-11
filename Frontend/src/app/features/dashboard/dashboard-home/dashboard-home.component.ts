import { CdkDragDrop, CdkDropList } from '@angular/cdk/drag-drop';
import { DOCUMENT } from '@angular/common';
import { AfterViewInit, ChangeDetectorRef, Component, ComponentFactoryResolver, Inject, OnDestroy, OnInit, QueryList, Renderer2, ViewChild, ViewChildren } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Store } from '@ngrx/store';
import { AttributesMap, dynamicDirectiveDef } from 'ng-dynamic-component';
import { take } from 'rxjs/operators';
import { MaterialElevationDirective } from 'src/business/directives/elevation.directive';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { UISidenav, UISidenavAction } from 'src/business/shared/ui-sidenavs.enum';
import { AppState } from 'src/ngrx/app/app.state';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';
import { SubSink } from 'subsink';
import { TrackItem } from '../../../../server-models/entities/track-item.model';
import { Track } from '../../../../server-models/entities/track.model';
import { DashboardOutletDirective } from '../directives/dashboard-outlet.directive';
import { dashboardCards, mainDashboardComponents } from '../models/dashboard-cards';
import { DashboardService } from '../services/dashboard.service';
import { currentUserId } from './../../../../ngrx/auth/auth.selectors';
import { sidebarCards } from './../models/dashboard-cards';

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styleUrls: ['./dashboard-home.component.scss'],
})
export class DashboardHomeComponent implements OnInit, AfterViewInit, OnDestroy {

  @ViewChildren(DashboardOutletDirective) dashboardOutlets: QueryList<DashboardOutletDirective>;

  @ViewChildren('trackOne, trackTwo') dropLists: QueryList<CdkDropList>;

  private userId: string;
  tracks: Track[];

  dashboardEditMode = false;
  attrs: AttributesMap = {
    class: 'dashboard-component',
  };
  dirs = [
    dynamicDirectiveDef(MaterialElevationDirective, { 'raisedElevation': 16 })
  ]

  sidebarCards = sidebarCards;
  dashboardCards = dashboardCards;
  mainDashboardComponents = mainDashboardComponents;

  @ViewChild(MatSidenav, { static: true }) sidenav: MatSidenav;
  private _subs = new SubSink();

  constructor(
    @Inject(DOCUMENT) private document,
    private notificationService: NotificationSignalrService,
    private store: Store<AppState>,
    private cd: ChangeDetectorRef,
    private cfr: ComponentFactoryResolver,
    private dashboardService: DashboardService,
    private UIService: UIService,
    private renderer: Renderer2
  ) { }

  ngOnInit() {
    this.document.getElementById('main-sidenav-content').style.setProperty("overflow-y", "hidden", "important")

    this.dashboardService.getUserTracks();

    this.store.select(currentUserId).pipe(take(1)).subscribe(userId => this.userId = userId);

    this.UIService.addOrUpdateSidenav(UISidenav.DashboardComponents, this.sidenav);

    this._subs.add(
      this.dashboardService.tracks$.subscribe(tracks => {
        this.tracks = tracks;
        // this.cd.detectChanges();
        // this.loadContents();
      }));
  }

  ngOnDestroy() {
    this.document.getElementById('main-sidenav-content').style.setProperty("overflow-y", "auto", "important")

    this._subs.unsubscribe();
  }

  ngAfterViewInit() {
    // this.loadContents();
  }

  activateNotif() {
    this.notificationService.sendNotification(
      NotificationType.TrainingCreated,
      "Test notification " + Math.round(Math.random() * 10) + " from client",
      this.userId,
      this.userId);
  }

  // loadContents = () => {
  //   if (!this.dashboardOutlets || !this.dashboardOutlets.length)
  //     return;

  //   this.dashboardOutlets.forEach(template => {
  //     this.cd.detectChanges();
  //     this.loadContent(template, template.item);
  //   });

  //   this.cd.detectChanges();
  // }

  // loadContent = (template: DashboardOutletDirective, item: TrackItem) => {
  //   if (!item.component)
  //     return;

  //   const viewContainerRef = template.viewContainerRef;
  //   viewContainerRef.clear();

  //   const factory = this.cfr.resolveComponentFactory(dashboardCards[item.component]);
  //   const componentRef = viewContainerRef.createComponent(factory);
  //   const instance = componentRef.instance as DashboardCardContainerComponent;
  //   instance.item = item;
  // }

  toggleSidenav = () => {
    setTimeout(() => this.dashboardEditMode = !this.dashboardEditMode, this.UIService.isSidenavOpened(UISidenav.DashboardComponents) ? 0 : 500);
    this.UIService.doSidenavAction(UISidenav.DashboardComponents, UISidenavAction.Toggle);
  }

  dashboardUpdated = false;
  drop(event: CdkDragDrop<TrackItem[]>, trackIdx: number = null) {

    // if (event.previousContainer === event.container) {
    //   // moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    // } else {
    if (event.previousContainer != event.container) {
      this.dashboardUpdated = true;
      const item = event.previousContainer.data[event.previousIndex];
      this.dashboardService.addItem(item, trackIdx);
      // this.mainDashboardComponents.splice(this.mainDashboardComponents.indexOf(item), 1);
      // transferArrayItem(
      //   event.previousContainer.data,
      //   event.container.data,
      //   event.previousIndex,
      //   event.currentIndex);
    }
  }

  onSaveDashboard() {
    if (this.dashboardUpdated) {
      this.dashboardService.saveMainDashboard(this.tracks);
    }
  }

  dragEnter(event: any) {
    const droplist = event.container;
    const draggedItem = event.item;

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
