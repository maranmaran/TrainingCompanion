import { Injectable } from "@angular/core";
import { Guid } from 'guid-typescript';
import { AttributesMap, dynamicDirectiveDef } from 'ng-dynamic-component';
import { BehaviorSubject } from 'rxjs';
import { MaterialElevationDirective } from 'src/business/directives/elevation.directive';
import { BaseService } from 'src/business/services/base.service';
import { TrackItem } from '../../../../server-models/entities/track-item.model';
import { Track } from '../../../../server-models/entities/track.model';

@Injectable({
  providedIn: 'root'
})
export class TracksService extends BaseService {

  trackItemAttributes: AttributesMap = { class: 'dashboard-component' };
  trackItemDirectives = [ dynamicDirectiveDef(MaterialElevationDirective, { raisedElevation: 16 }) ]
  defaultState: Track[] = [
    {
      id: Guid.create().toString(),
      items: []
    },
    {
      id: Guid.create().toString(),
      items: []
    }
  ]

  private _trackState = new BehaviorSubject<Track[]>(this.defaultState);
  tracks$ = this._trackState.asObservable();

  //Sets new tracks state
  setState(tracks: Track[]) {
    this._trackState.next(tracks);
  }

  // adds item to track
  addItem = (item: TrackItem, trackIdx: number) => {
    const state = this._trackState.getValue();

    state[trackIdx].items.push(item);

    this._trackState.next(state);
  }

  // removes item from track
  removeItem = (item: TrackItem) => {
    const state = this._trackState.getValue();

    state.forEach(track => {
      track.items.forEach((i, index) => {
        if (i == item) {
          track.items.splice(index, 1);
        }
      })
    });

    this._trackState.next(state);
  }
}
