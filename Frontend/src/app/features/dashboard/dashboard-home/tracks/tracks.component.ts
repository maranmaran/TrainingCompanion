import { CdkDragDrop, CdkDropList } from '@angular/cdk/drag-drop';
import { Component, EventEmitter, OnInit, Output, QueryList, ViewChildren } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { Store } from '@ngrx/store';
import { AttributesMap } from 'ng-dynamic-component';
import { Observable } from 'rxjs';
import { removeTrackItem } from 'src/ngrx/dashboard/dashboard.actions';
import { trackEditMode, tracks } from 'src/ngrx/dashboard/dashboard.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { TrackItem } from 'src/server-models/entities/track-item.model';
import { Track } from 'src/server-models/entities/track.model';
import { dashboardCards } from '../../models/dashboard-cards';

@Component({
  selector: 'app-tracks',
  templateUrl: './tracks.component.html',
  styleUrls: ['./tracks.component.scss']
})
export class TracksComponent implements OnInit {

  @ViewChildren('trackOne, trackTwo') trackDroplists: QueryList<CdkDropList>; // needed for parent component to access

  tracks: Observable<Track[]>;
  dashboardCards = dashboardCards;
  attrs: AttributesMap = { class: 'dashboard-component' };


  exerciseTypes: ExerciseType[];
  //TODO: Directives in ndcDynamic have trouble with angular AOT - see issue on their github
  // dirs: DynamicDirectiveDef<any>[] = [ dynamicDirectiveDef(MaterialElevationDirective, { raisedElevation: 16 }) ];

  @Output() dragEnter = new EventEmitter<any>()
  @Output() dragEnd = new EventEmitter()
  @Output() drop = new EventEmitter<{ event: CdkDragDrop<TrackItem[]>, trackIdx: number }>();

  constructor(
    private store: Store<AppState>,
    public mediaObserver: MediaObserver
  ) { }

  ngOnInit(): void {

    // // TODO: use resolver for this
    // this.store.select(currentUserId).pipe(take(1)).subscribe(id => {
    //   this.dashboardService.getUserTracks(id);
    // });

    this.tracks = this.store.select(tracks);
  }

  trackCardsFn(index, item) {
    return item.id;
  }


}
