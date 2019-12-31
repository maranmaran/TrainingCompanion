import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';

@Injectable()
export class ExportImportResolver implements Resolve<void> {

    constructor(
        private store: Store<AppState>
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

      return;

        // return this.store.select(currentUser)
        //     .pipe(
        //         take(1),
        //         map((user: CurrentUser) => user.id),
        //         concatMap((userId: string) => {
        //             return this.getState(userId);
        //         }));
    }

    // private getState(userId: string) {

    //     return this.store
    //         .select(exerciseTypes)
    //         .pipe(
    //             take(1),
    //             concatMap((exerciseTypes: ExerciseType[]) => {

    //             if (isEmpty(exerciseTypes)) {
    //                 return this.updateState(userId);
    //             }

    //             return of(exerciseTypes);
    //         }));
    // }

    // private updateState(userId: string) {

    //     return this.exerciseTypeService.getAll(userId)
    //     .pipe(
    //         take(1),
    //         map(((exerciseTypes: ExerciseType[]) => {
    //             this.store.dispatch(exerciseTypesFetched({ entities: exerciseTypes}));
    //         }))
    //     );
    // }
}

