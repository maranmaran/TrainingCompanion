import { ExercisePropertyTypeService } from './../services/exercise-property-type.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { athletesFetched } from 'src/ngrx/athletes/athlete.actions';
import { athletes } from 'src/ngrx/athletes/athlete.selectors';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { currentUser } from '../../ngrx/auth/auth.selectors';
import { UserService } from '../services/user.service';
import { AccountType } from 'src/server-models/enums/account-type.enum';
import { ExercisePropertyType } from 'src/server-models/entities/exercise-property-type.model';
import { exercisePropertyTypes } from 'src/ngrx/exercise-property-type/exercise-property-type.selectors';
import { exercisePropertyTypesFetched } from 'src/ngrx/exercise-property-type/exercise-property-type.actions';

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
            .select(exercisePropertyTypes)
            .pipe(
                take(1), 
                concatMap((propertyTypes: ExercisePropertyType[]) => {

                if (!propertyTypes) {
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

