import { normalizeTrainings } from '../../ngrx/training-log/training/training.actions';
import { LocalStorageKeys } from '../shared/localstorage.keys.enum';
import { TrainingService } from '../services/feature-services/training.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Training } from 'src/server-models/entities/training.model';
import { selectedTrainingId, selectedTraining } from 'src/ngrx/training-log/training/training.selectors';
import { trainingsFetched, setSelectedTraining } from 'src/ngrx/training-log/training/training.actions';
import { CRUD } from '../shared/crud.enum';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { UIProgressBar } from '../shared/ui-progress-bars.enum';

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
                    if(!id) {
                        id = localStorage.getItem(LocalStorageKeys.trainingId);
                        return this.getState(id);
                    } 

                    return this.store.select(selectedTraining).pipe(take(1));
                }));
    }

    private getState(id: string) {

        this.store.dispatch(setActiveProgressBar({ progressBar: UIProgressBar.SplashScreen}));

        return this.trainingService.getOne(id)
        .pipe(
            take(1),
            map(((training: Training) => {
                this.store.dispatch(normalizeTrainings({entities: [training], action: CRUD.Read}));
                this.store.dispatch(setSelectedTraining({entity: training}));

                return training;
            }))
        );
    }
}

