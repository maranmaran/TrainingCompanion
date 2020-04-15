import { CdkDragDrop, CdkDropList } from '@angular/cdk/drag-drop';
import { Component, EventEmitter, OnInit, Output, QueryList, ViewChildren } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { Store } from '@ngrx/store';
import { AttributesMap } from 'ng-dynamic-component';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { tracks, trackEditMode } from 'src/ngrx/dashboard/dashboard.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { Track } from 'src/server-models/entities/track.model';
import { dashboardCards } from '../../models/dashboard-cards';
import { DashboardService } from './../../services/dashboard.service';
import { removeTrackItem } from 'src/ngrx/dashboard/dashboard.actions';

@Component({
  selector: 'app-tracks',
  templateUrl: './tracks.component.html',
  styleUrls: ['./tracks.component.scss']
})
export class TracksComponent implements OnInit {

  @ViewChildren('trackOne, trackTwo') trackDroplists: QueryList<CdkDropList>; // needed for parent component to access

  tracks: Observable<Track[]>;
  dashboardCards = dashboardCards;
  attrs: AttributesMap = { class: 'dashboard-component mat-elevation-z3' };

  editMode: Observable<boolean>;

  exerciseTypes: ExerciseType[];
  //TODO: Directives in ndcDynamic have trouble with angular AOT - see issue on their github
  // dirs: DynamicDirectiveDef<any>[] = [ dynamicDirectiveDef(MaterialElevationDirective, { raisedElevation: 16 }) ];

  @Output() dragEnter = new EventEmitter<any>()
  @Output() dragEnd = new EventEmitter()
  @Output() drop = new EventEmitter<{ event: CdkDragDrop<TrackItem[]>, trackIdx: number }>();

  constructor(
    private store: Store<AppState>,
    private dashboardService: DashboardService,
    public mediaObserver: MediaObserver
  ) { }

  ngOnInit(): void {
    this.editMode = this.store.select(trackEditMode);

    // TODO: use resolver for this
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => {
      this.dashboardService.getUserTracks(id);
    });

    this.tracks = this.store.select(tracks);
  }

  removeTrackItem(trackItem: TrackItem, idx: number) {
    console.log(trackItem);
    this.store.dispatch(removeTrackItem({ item: trackItem, idx }))
  }



}
