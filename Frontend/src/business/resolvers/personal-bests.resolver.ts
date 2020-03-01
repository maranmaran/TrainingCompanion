import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { personalBests } from 'src/ngrx/personal-best/personal-best.selectors';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { PersonalBest } from 'src/server-models/entities/personal-best.model';
import { currentUser } from '../../ngrx/auth/auth.selectors';
import { PersonalBestService } from '../services/feature-services/personal-best.service';
import { isEmpty } from '../utils/utils';
import { personalBestFetched } from './../../ngrx/personal-best/personal-best.actions';

@Injectable()
export class PersonalBestsResolver implements Resolve<Observable<PersonalBest[] | void>> {

  constructor(
    private personalBestService: PersonalBestService,
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
      .select(personalBests)
      .pipe(
        take(1),
        concatMap((personalBests: PersonalBest[]) => {

          if (isEmpty(personalBests)) {
            return this.updateState(userId);
          }

          return of(personalBests);
        }));
  }

  private updateState(userId: string) {

    return this.personalBestService.getAll(userId)
      .pipe(
        take(1),
        map((entities: PersonalBest[]) => {
          this.store.dispatch(personalBestFetched({ entities }));
        }))
  }
}
