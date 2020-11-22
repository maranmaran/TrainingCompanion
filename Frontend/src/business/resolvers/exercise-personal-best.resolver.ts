import { selectedTrainingId } from './../../ngrx/training-log/training.selectors';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { catchError, filter, map, switchMap, take, tap, concatMap } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { exercisePrsFetched } from 'src/ngrx/exercise/exercise.actions';
import { selectedExercise } from 'src/ngrx/exercise/exercise.selectors';
import { PersonalBest } from './../../server-models/entities/personal-best.model';
import { PersonalBestService } from './../services/feature-services/personal-best.service';

// TODO: This triggers 2 times when going from training details to exercise details
@Injectable()
export class ExercisePersonalBestResolver implements Resolve<Observable<PersonalBest[]>> {

  constructor(
    private prService: PersonalBestService,
    private store: Store<AppState>
  ) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.store.select(selectedExercise)
      .pipe(
        filter(exercise => !!exercise),
        switchMap(exercise => this.prService.get(exercise.exerciseType?.id).pipe(map(prs => [exercise.id, prs]))),
        catchError(_ => []),
        take(1),
        tap(([id, prs]) => this.store.dispatch(exercisePrsFetched({ exerciseId: id, prs })))
      )
  }
}
