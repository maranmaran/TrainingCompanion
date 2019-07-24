import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { EMPTY, Observable, of } from 'rxjs';
import { catchError, concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { mediaFetched } from 'src/ngrx/media/media.actions';
import { getSelectorByMediaType } from 'src/ngrx/media/media.selectors';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { MediaType } from 'src/server-models/enums/media-type.enum';
import { MediaService } from '../services/media.service';
import { currentUser } from './../../ngrx/auth/auth.selectors';

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

