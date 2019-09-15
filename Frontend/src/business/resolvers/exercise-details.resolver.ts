import { LocalStorageKeys } from './../shared/localstorage.keys.enum';
import { ExerciseService } from '../services/feature-services/exercise.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { normalizeExercise, setSelectedExercise } from 'src/ngrx/training-log/exercise/exercise.actions';
import { CRUD } from '../shared/crud.enum';
import { selectedExercise, selectedExerciseId } from 'src/ngrx/training-log/exercise/exercise.selectors';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { UIProgressBar } from '../shared/ui-progress-bars.enum';

@Injectable()
export class ExerciseDetailsResolver implements Resolve<Observable<Exercise | void>> {

    constructor(
        private exerciseService: ExerciseService,
        private store: Store<AppState>
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        return this.store.select(selectedExerciseId)
            .pipe(
                take(1), 
                concatMap((id: string) => {
                    if(!id) {
                        id = localStorage.getItem(LocalStorageKeys.exerciseId);
                        return this.getState(id);
                    } 

                    return this.store.select(selectedExercise).pipe(take(1));
                }));
    }

    private getState(id: string) {

        return this.exerciseService.getOne(id)
        .pipe(
            take(1),
            map(((exercise: Exercise) => {
                this.store.dispatch(normalizeExercise({ exercise, action: CRUD.Read }));
                this.store.dispatch(setSelectedExercise({entity: exercise}));

                return exercise;
            }))
        );
    }
}

