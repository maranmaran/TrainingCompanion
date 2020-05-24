import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { catchError, filter, map, switchMap, take, tap } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { exercisePrsFetched } from 'src/ngrx/training-log/training.actions';
import { selectedExercise } from 'src/ngrx/training-log/training.selectors';
import { PersonalBest } from './../../server-models/entities/personal-best.model';
import { PersonalBestService } from './../services/feature-services/personal-best.service';

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
        map(exercise => exercise.exerciseType?.id),
        switchMap(id => this.prService.get(id)),
        catchError(_ => []),
        take(1),
        tap(prs => this.store.dispatch(exercisePrsFetched({ prs })))
      )
  }
}
