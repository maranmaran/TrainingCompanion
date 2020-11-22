import { selectedTrainingId } from './../../ngrx/training-log/training.selectors';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { combineLatest, Observable, of } from 'rxjs';
import { catchError, filter, map, switchMap, take, tap, concatMap } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { exerciseFetched, exercisePrsFetched, setSelectedExercise } from 'src/ngrx/exercise/exercise.actions';
import { exercisePrsDict, exercisesDict, selectedExercise, selectedExerciseId } from 'src/ngrx/exercise/exercise.selectors';
import { PersonalBest } from './../../server-models/entities/personal-best.model';
import { PersonalBestService } from './../services/feature-services/personal-best.service';
import { LocalStorageKeys } from 'src/business/shared/localstorage.keys.enum';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Guid } from 'guid-typescript';
import { userSetting } from 'src/ngrx/auth/auth.selectors';

// TODO: This triggers 2 times when going from training details to exercise details
@Injectable()
export class ExercisePersonalBestResolver implements Resolve<Observable<PersonalBest[]>> {

  constructor(
    private prService: PersonalBestService,
    private store: Store<AppState>
  ) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    return combineLatest([
      this.store.select(selectedExerciseId),
      this.store.select(exercisePrsDict),
      this.store.select(userSetting),
    ]).pipe(
      take(1),
      concatMap(([id, data, settings]) => {

        if(!settings.usePercentages) {
          return of([null, null]);
        }

        // Training selected
        if (id) {

          // if data exists.. returselectedExercisen it otherwise fetch new
          return data ? of(data) : this.getState(id as string);
        }

        id = localStorage.getItem(LocalStorageKeys.exerciseId);

        return this.getState(id);
      }));
  }

  private getState(id: string) {

    return this.prService.get(Guid.EMPTY, id)
      .pipe(
        take(1),
        map((prs: PersonalBest[]) => {
          this.store.dispatch(exercisePrsFetched({ exerciseId: id, prs }));
          return prs;
        }))
  }
}
