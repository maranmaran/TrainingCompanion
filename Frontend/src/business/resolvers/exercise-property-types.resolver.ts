import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { currentUser } from '../../ngrx/auth/auth.selectors';
import { ExercisePropertyTypeService } from '../services/feature-services/exercise-property-type.service';
import { exercisePropertyTypesFetched } from 'src/ngrx/exercise-property-type/exercise-property-type.actions';
import { allExercisePropertyTypes } from 'src/ngrx/exercise-property-type/exercise-property-type.selectors';
import { isEmpty } from '../utils/utils';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { UIProgressBar } from '../shared/ui-progress-bars.enum';

@Injectable()
export class ExercisePropertyTypesResolver implements Resolve<Observable<ExercisePropertyType[] | void>> {

    constructor(
        private exercisePropertyTypeService: ExercisePropertyTypeService,
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
            .select(allExercisePropertyTypes)
            .pipe(
                take(1), 
                concatMap((propertyTypes: ExercisePropertyType[]) => {

                if (isEmpty(propertyTypes)) {
                    return this.updateState(userId);
                }
                        
                return of(propertyTypes);
            }));
    }

    private updateState(userId: string) {

        return this.exercisePropertyTypeService.getAll(userId)
        .pipe(
            take(1),
            map(((propertyTypes: ExercisePropertyType[]) => {
                this.store.dispatch(exercisePropertyTypesFetched({propertyTypes}));
            }))
        );
    }
}

