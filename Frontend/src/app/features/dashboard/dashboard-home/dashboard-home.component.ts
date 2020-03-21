import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Component, OnInit, Renderer2, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { UISidenav } from 'src/business/shared/ui-sidenavs.enum';
import { addTrackItem } from 'src/ngrx/dashboard/dashboard.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { Track } from 'src/server-models/entities/track.model';
import { UIService } from './../../../../business/services/shared/ui.service';
import { currentUserId } from './../../../../ngrx/auth/auth.selectors';
import { DashboardService } from './../services/dashboard.service';
import { TracksComponent } from './tracks/tracks.component';

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styleUrls: ['./dashboard-home.component.scss'],
})
export class DashboardHomeComponent implements OnInit {

  @ViewChild(MatSidenav, { static: true }) sidenav: MatSidenav;
  @ViewChild(TracksComponent, { static: true }) tracksWrapper: TracksComponent;

  constructor(
    private store: Store<AppState>,
    private UIService: UIService,
    private renderer: Renderer2,
    private dashboardService: DashboardService,
  ) {
  }

  ngOnInit() {
    this.UIService.addOrUpdateSidenav(UISidenav.DashboardComponents, this.sidenav);
  }

  onSaveTracks(tracks: Track[]) {
    this.store.select(currentUserId).pipe(take(1))
    .subscribe(id => this.dashboardService.saveMainDashboard(id, tracks));
  }

  drop(data: {event: CdkDragDrop<TrackItem[]>, trackIdx: number}) {

    if (data.event.previousContainer.id != data.event.container.id) {
      const item = data.event.previousContainer.data[data.event.previousIndex];

      if(data.event.container.data.length < 3) {
        this.store.dispatch(addTrackItem({item, idx: data.trackIdx}));
      } else {
        this.UIService.fadeOutMessage("Can't add more than 3 items to one track", 2000)
      }
    }

  }

  dragEnter(event: any) {
    const droplist = event.container;

    this.tracksWrapper.trackDroplists.filter(list => list.id != droplist.id).forEach(droplist => {
      this.renderer.removeClass(droplist.element.nativeElement, 'theme-hover-background')
    });

    this.tracksWrapper.trackDroplists.filter(list => list.id == droplist.id).forEach(droplist => {
      this.renderer.addClass(droplist.element.nativeElement, 'theme-hover-background')
    });
  }

  dragEnd() {
    this.tracksWrapper.trackDroplists.filter(list => list.element.nativeElement.classList.contains('theme-hover-background')).forEach(droplist => {
      this.renderer.removeClass(droplist.element.nativeElement, 'theme-hover-background')
    });
  }

}
