import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { currentUser } from '../../ngrx/auth/auth.selectors';
import { TagGroupService } from '../services/feature-services/tag-group.service';
import { tagGroupsFetched } from 'src/ngrx/tag-group/tag-group.actions';
import { allTagGroups } from 'src/ngrx/tag-group/tag-group.selectors';
import { isEmpty } from '../utils/utils';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { UIProgressBar } from '../shared/ui-progress-bars.enum';

@Injectable()
export class TagGroupsResolver implements Resolve<Observable<TagGroup[] | void>> {

    constructor(
        private tagGroupService: TagGroupService,
        private store: Store<AppState>
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        return this.store.select(currentUser)
            .pipe(
                take(1),
                map((user: CurrentUser) => user.id),
                concatMap((userId: string) => {
                    return this.getState(userId);
                }));
    }

    private getState(userId: string) {

        return this.store
            .select(allTagGroups)
            .pipe(
                take(1),
                concatMap((tagGroups: TagGroup[]) => {

                    if (isEmpty(tagGroups)) {
                        return this.updateState(userId);
                    }

                    return of(tagGroups);
                }));
    }

    private updateState(userId: string) {

        return this.tagGroupService.getAll(userId)
            .pipe(
                take(1),
                map(((tagGroups: TagGroup[]) => {
                    this.store.dispatch(tagGroupsFetched({ tagGroups }));
                }))
            );
    }
}
