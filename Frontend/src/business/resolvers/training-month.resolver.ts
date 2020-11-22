import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, combineLatest, of } from 'rxjs';
import { take, concatMap, map } from 'rxjs/operators';
import { MediaService } from 'src/business/services/feature-services/media.service';
import { LocalStorageKeys } from 'src/business/shared/localstorage.keys.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setTrainingMedia } from 'src/ngrx/training-log/training.actions';
import { selectedTrainingId, trainingMediaDict } from 'src/ngrx/training-log/training.selectors';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { Training } from 'src/server-models/entities/training.model';

// TODO: Not used
@Injectable()
export class TrainingMonthResolver implements Resolve<Observable<Training> | Observable<unknown>> {

    constructor(
        private mediaService: MediaService,
        private store: Store<AppState>,
        private router: Router,
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        throw new Error("Not Implemented.. needs state implementation");
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