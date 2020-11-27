import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of, combineLatest } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { isEmpty } from 'src/business/utils/utils';
import { exercises, exercisesDict } from 'src/ngrx/exercise/exercise.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedTrainingId } from 'src/ngrx/training-log/training.selectors';
import { Training } from 'src/server-models/entities/training.model';
import { LocalStorageKeys } from '../shared/localstorage.keys.enum';
import { exerciseFetched, setSelectedExercise } from './../../ngrx/exercise/exercise.actions';
import { Exercise } from './../../server-models/entities/exercise.model';
import { ExerciseService } from './../services/feature-services/exercise.service';


@Injectable()
export class TrainingExercisesResolver implements Resolve<Observable<Training> | Observable<unknown>> {

    constructor(
        private exerciseService: ExerciseService,
        private store: Store<AppState>,
        private router: Router,
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        return combineLatest([
            this.store.select(selectedTrainingId),
            this.store.select(exercisesDict),
        ]).pipe(
            take(1),
            concatMap(([id, data]) => {

                id = id || route.queryParamMap.get('trainingId');

                // Training selected
                if (id) {

                    // if data exists.. return it otherwise fetch new
                    return data ? of(data) : this.getState(id as string);
                }

                id = localStorage.getItem(LocalStorageKeys.trainingId);

                return this.getState(id);
            }));
    }

    private getState(id: string) {

        return this.exerciseService.getAll(id)
            .pipe(
                take(1),
                map((entities: Exercise[]) => {
                    this.store.dispatch(exerciseFetched({ trainingId: id, entities }));

                    // select exercise here.. because resolvers are executed in parallel
                    // we need entities in first place to select an entity..
                    let exerciseId = localStorage.getItem(LocalStorageKeys.exerciseId);

                    if (exerciseId) {
                        let exercise = entities.filter(x => x.id == exerciseId)[0];
                        this.store.dispatch(setSelectedExercise({ entity: exercise }));
                    }

                    return entities;
                }))
    }
}
