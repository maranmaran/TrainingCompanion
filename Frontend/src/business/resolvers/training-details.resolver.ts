import { LocalStorageKeys } from '../shared/localstorage.keys.enum';
import { TrainingService } from '../services/feature-services/training.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Training } from 'src/server-models/entities/training.model';
import { CRUD } from '../shared/crud.enum';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { UIProgressBar } from '../shared/ui-progress-bars.enum';
import { selectedTrainingId, selectedTraining } from 'src/ngrx/training-log/training2/training.selectors';
import { trainingsFetched, setSelectedTraining, setSelectedExercise } from 'src/ngrx/training-log/training2/training.actions';

@Injectable()
export class TrainingDetailsResolver implements Resolve<Observable<Training | void>> {

    constructor(
        private trainingService: TrainingService,
        private store: Store<AppState>
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        return this.store.select(selectedTrainingId)
            .pipe(
                take(1),
                concatMap((id: string) => {
                    if (!id) {
                        id = localStorage.getItem(LocalStorageKeys.trainingId);
                        return this.getState(id);
                    }

                    return this.store.select(selectedTraining).pipe(take(1));
                }));
    }

    private getState(id: string) {

        return this.trainingService.getOne(id)
            .pipe(
                take(1),
                map(((training: Training) => {
                    this.store.dispatch(trainingsFetched({ entities: [training] }));
                    // this.store.dispatch(normalizeTrainings({entities: [training], action: CRUD.Read}));
                    this.store.dispatch(setSelectedTraining({ entity: training }));

                    let exerciseId = localStorage.getItem(LocalStorageKeys.exerciseId);
                    if (exerciseId) {
                        let exercise = training.exercises.filter(x => x.id == exerciseId)[0];
                        this.store.dispatch(setSelectedExercise({ entity: exercise }));
                    }

                    return training;
                }))
            );
    }
}
