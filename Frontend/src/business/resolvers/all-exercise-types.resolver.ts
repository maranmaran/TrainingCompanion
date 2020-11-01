import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { allExerciseTypesFetched } from 'src/ngrx/exercise-type/exercise-type.actions';
import { exerciseTypes } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { currentUser } from '../../ngrx/auth/auth.selectors';
import { ExerciseTypeService } from '../services/feature-services/exercise-type.service';
import { isEmpty } from '../utils/utils';

@Injectable()
export class AllExerciseTypesResolver implements Resolve<Observable<ExerciseType[] | void>> {

  constructor(
    private exerciseTypeService: ExerciseTypeService,
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
      .select(exerciseTypes)
      .pipe(
        take(1),
        concatMap((exerciseTypes: ExerciseType[]) => {

          if (isEmpty(exerciseTypes)) {
            return this.updateState(userId);
          }

          return of(exerciseTypes);
        }));
  }

  private updateState(userId: string) {

    return this.exerciseTypeService.getAll(userId)
      .pipe(
        take(1),
        map((types: ExerciseType[]) => {
          this.store.dispatch(allExerciseTypesFetched({ entities: types }));
        }))
  }
}
