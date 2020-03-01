import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { bodyweights } from 'src/ngrx/bodyweight/bodyweight.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { Bodyweight } from 'src/server-models/entities/bodyweight.model';
import { currentUser } from '../../ngrx/auth/auth.selectors';
import { BodyweightService } from '../services/feature-services/bodyweight.service';
import { isEmpty } from '../utils/utils';
import { bodyweightFetched } from './../../ngrx/bodyweight/bodyweight.actions';

@Injectable()
export class BodyweightsResolver implements Resolve<Observable<Bodyweight[] | void>> {

  constructor(
    private bodyweightService: BodyweightService,
    private store: Store<AppState>
  ) { }


  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    return this.store.select(currentUser)
      .pipe(
        take(1),
        map((user: CurrentUser) => user.id),
        concatMap((userId: string) => {
          return this.getState(userId);
        }));
  }

  private getState(userId: string) {

    return this.store
      .select(bodyweights)
      .pipe(
        take(1),
        concatMap((bodyweights: Bodyweight[]) => {

          if (isEmpty(bodyweights)) {
            return this.updateState(userId);
          }

          return of(bodyweights);
        }));
  }

  private updateState(userId: string) {

    return this.bodyweightService.getAll(userId)
      .pipe(
        take(1),
        map((entities: Bodyweight[]) => {
          this.store.dispatch(bodyweightFetched({ entities }));
        }))
  }
}
