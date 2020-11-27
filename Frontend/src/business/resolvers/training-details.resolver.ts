import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setSelectedTraining, trainingsFetched } from 'src/ngrx/training-log/training.actions';
import { selectedTraining, selectedTrainingId } from 'src/ngrx/training-log/training.selectors';
import { Training } from 'src/server-models/entities/training.model';
import { TrainingService } from '../services/feature-services/training.service';
import { LocalStorageKeys } from '../shared/localstorage.keys.enum';

// Handle fetching training if we do refresh
@Injectable()
export class TrainingDetailsResolver implements Resolve<Observable<Training> | Observable<unknown>> {

    constructor(
        private trainingService: TrainingService,
        private store: Store<AppState>,
        private router: Router,
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        return this.store.select(selectedTrainingId)
            .pipe(
                take(1),
                concatMap((id: string) => {

                    if (id) {
                        return this.store.select(selectedTraining).pipe(take(1));
                    }

                    id = localStorage.getItem(LocalStorageKeys.trainingId) || 
                         route.queryParamMap.get('trainingId');

                    if (!id) {
                        return of(this.router.navigate(['/app/training-log']))
                    }

                    console.log(route.url)
                    return this.getState(id);
                }));
    }

    private getState(id: string) {

        return this.trainingService.getOne(id)
            .pipe(
                take(1),
                map(((training: Training) => {
                    this.store.dispatch(trainingsFetched({ entities: [training] }));
                    this.store.dispatch(setSelectedTraining({ id }));
                    return training;
                }))
            );
    }
}

