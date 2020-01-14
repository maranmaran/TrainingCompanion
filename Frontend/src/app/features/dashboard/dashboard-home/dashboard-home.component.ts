import { Component, OnInit, ViewChildren, QueryList, ChangeDetectorRef, ComponentFactoryResolver, AfterViewInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service';
import { AppState } from 'src/ngrx/app/app.state';
import { NotificationType } from 'src/server-models/enums/notification-type.enum';
import { currentUserId } from './../../../../ngrx/auth/auth.selectors';
import { DashboardOutletDirective } from '../directives/dashboard-outlet.directive';
import { DashboardItem } from '../models/dashboard-item.interface';
import { dashboardCards, DashboardCards } from '../models/dashboard-cards';
import { DashboardCardContainerComponent } from '../dashboard-card-container/dashboard-card-container.component';
import { Track } from '../models/track.interface';
import { DashboardService } from '../services/dashboard.service';

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styleUrls: ['./dashboard-home.component.scss']
})
export class DashboardHomeComponent implements OnInit, AfterViewInit {

  @ViewChildren(DashboardOutletDirective) dashboardOutlets: QueryList<DashboardOutletDirective>;
  private userId: string;
  tracks: Track[];
 

  constructor(
    private notificationService: NotificationSignalrService,
    private store: Store<AppState>,
    private cd: ChangeDetectorRef,
    private cfr: ComponentFactoryResolver,
    private dashboardService: DashboardService
  ) { }

  ngOnInit() {
    this.store.select(currentUserId).pipe(take(1)).subscribe(userId => this.userId = userId);

    this.dashboardService.tracks$.subscribe(tracks => {
      this.tracks = tracks;
      this.cd.detectChanges();
      this.loadContents();
    });
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
    if(!this.dashboardOutlets || !this.dashboardOutlets.length) 
      return;

      this.dashboardOutlets.forEach(template => {
        this.cd.detectChanges();
        this.loadContent(template, template.item);
      });

      this.cd.detectChanges();
  }

  loadContent = (template: DashboardOutletDirective, item: DashboardItem) => {
    if (!item.component)
      return;

    const viewContainerRef = template.viewContainerRef;
    viewContainerRef.clear();

    const factory = this.cfr.resolveComponentFactory(dashboardCards[item.component]);
    const componentRef = viewContainerRef.createComponent(factory);
    const instance = componentRef.instance as DashboardCardContainerComponent;
    instance.item = item;
  }



}
