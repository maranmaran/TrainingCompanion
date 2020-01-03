import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { exerciseTypesFetched } from 'src/ngrx/exercise-type/exercise-type.actions';
import { exerciseTypes } from 'src/ngrx/exercise-type/exercise-type.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { currentUser } from '../../ngrx/auth/auth.selectors';
import { ExerciseTypeService } from '../services/feature-services/exercise-type.service';
import { isEmpty } from '../utils/utils';
import { PagingModel } from './../../app/shared/material-table/table-models/paging.model';
import { PagedList } from './../../server-models/shared/paged-list.model';

@Injectable()
export class ExerciseTypesResolver implements Resolve<Observable<ExerciseType[] | void>> {

    constructor(
        private exerciseTypeService: ExerciseTypeService,
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
            .select(exerciseTypes)
            .pipe(
                take(1),
                map(state => state.entities),
                concatMap((exerciseTypes: ExerciseType[]) => {

                if (isEmpty(exerciseTypes)) {
                    return this.updateState(userId);
                }

                return of(exerciseTypes);
            }));
    }

    private updateState(userId: string) {

        let defaultPagingModel = new PagingModel();
        defaultPagingModel.sortBy = 'name';
        defaultPagingModel.sortDirection = 'asc';

        return this.exerciseTypeService.getPaged(userId, defaultPagingModel)
        .pipe(
            take(1),
            map(((pagedListModel: PagedList<ExerciseType>) => {
                this.store.dispatch(exerciseTypesFetched({ entities: pagedListModel.list, totalItems: pagedListModel.totalItems, pagingModel: defaultPagingModel }));
            }))
        );
    }
}
