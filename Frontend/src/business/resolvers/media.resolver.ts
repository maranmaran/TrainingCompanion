import { MediaFile } from 'src/server-models/entities/media-file.model';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { EMPTY, of, Observable } from 'rxjs';
import { catchError, concatMap, map, take } from 'rxjs/operators';
import { updateCurrentUser } from 'src/ngrx/auth/auth.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { disableErrorSnackbar, setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { UIProgressBar } from '../shared/ui-progress-bars.enum';
import { currentUser } from './../../ngrx/auth/auth.selectors';
import { MediaService } from '../services/media.service';
import { MediaType } from 'src/server-models/enums/media-type.enum';
import { images, videos, files, getSelectorByMediaType } from 'src/ngrx/media/media.selectors';
import { MatExpansionPanelDescription } from '@angular/material/expansion';
import { mediaFetched } from 'src/ngrx/media/media.actions';

@Injectable()
export class MediaResolver implements Resolve<Observable<MediaFile[] | void>> {

    constructor(
        private router: Router,
        private mediaService: MediaService,
        private store: Store<AppState>
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        return this.store.select(currentUser)
            .pipe(
                take(1), 
                map((user: CurrentUser) => user.id),
                concatMap((userId: string) => {
                    const type = route.data['type'];

                    return this.getMediaForUser(userId, type);
                }));
    }

    private getMediaForUser(userId: string, type: MediaType) {
        let selector = getSelectorByMediaType(type);

        return this.store
            .select(selector)
            .pipe(
                take(1), 
                concatMap((media: MediaFile[]) => {

                if (!media) {
                    return this.updateMediaState(userId, type);
                }
                        
                return of(media);
            }));
    }

    private updateMediaState(userId: string, type: MediaType) {

        return this.mediaService.getUserMediaByType(userId, type)
        .pipe(
            take(1),
            catchError(() => {
                this.router.navigate(['/auth/login']);
                return EMPTY;
            }),
            map((media: MediaFile[]) => {
                this.store.dispatch(mediaFetched({ payload: { media, type } }));
            })
        );
    }
}

