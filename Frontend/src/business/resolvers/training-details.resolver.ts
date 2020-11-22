import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of, combineLatest } from 'rxjs';
import { concatMap, map, take, mergeMap } from 'rxjs/operators';
import { MediaService } from 'src/business/services/feature-services/media.service';
import { isEmpty } from 'src/business/utils/utils';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setSelectedTraining, trainingsFetched } from 'src/ngrx/training-log/training.actions';
import { selectedTraining, selectedTrainingId, trainingMedia, trainingMediaDict } from 'src/ngrx/training-log/training.selectors';
import { Training } from 'src/server-models/entities/training.model';
import { TrainingService } from '../services/feature-services/training.service';
import { LocalStorageKeys } from '../shared/localstorage.keys.enum';
import { setTrainingMedia } from './../../ngrx/training-log/training.actions';
import { MediaFile } from './../../server-models/entities/media-file.model';

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

                    id = localStorage.getItem(LocalStorageKeys.trainingId);

                    if (!id) {
                        return of(this.router.navigate(['/app/training-log']))
                    }

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

@Injectable()
export class TrainingMediaResolver implements Resolve<Observable<Training> | Observable<unknown>> {

    constructor(
        private mediaService: MediaService,
        private store: Store<AppState>,
        private router: Router,
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        return combineLatest([
                this.store.select(selectedTrainingId),
                this.store.select(trainingMediaDict)
            ])
            .pipe(
                take(1),
                concatMap(([id, data]) => {

                    // Training selected
                    if (id) {

                        // if data exists.. return it otherwise fetch new
                        return data ? of(data) : this.getState(id as string);
                    }

                    // probably refresh
                    id = localStorage.getItem(LocalStorageKeys.trainingId);

                    // either reroute back
                    if (!id) {
                        return of(this.router.navigate(['/app/training-log']))
                    }

                    // or fetch data again
                    return this.getState(id);
                }));
    }

    private getState(id: string) {

        return this.mediaService.getTrainingMedia(id as string)
            .pipe(
                take(1),
                map(((media: MediaFile[]) => {
                    this.store.dispatch(setTrainingMedia({ id, media }));
                    return media;
                }))
            );
    }
}
