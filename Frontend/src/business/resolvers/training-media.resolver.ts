import { MediaService } from 'src/business/services/feature-services/media.service';
import { LocalStorageKeys } from './../shared/localstorage.keys.enum';
import { concatMap, take, map } from 'rxjs/operators';
import { Observable, combineLatest, of } from 'rxjs';
import { AppState } from './../../ngrx/global-setup.ngrx';
import { selectedTrainingId, trainingMediaDict } from './../../ngrx/training-log/training.selectors';
import { Training } from './../../server-models/entities/training.model';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { MediaFile } from '../../server-models/entities/media-file.model';
import { Store } from '@ngrx/store';
import { setTrainingMedia } from '../../ngrx/training-log/training.actions';

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