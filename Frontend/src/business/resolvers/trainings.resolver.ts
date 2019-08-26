import { TrainingService } from './../services/training.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { currentUser } from '../../ngrx/auth/auth.selectors';
import { Training } from 'src/server-models/entities/training.model';
import { trainings } from 'src/ngrx/training/training.selectors';
import { trainingsFetched } from 'src/ngrx/training/training.actions';

// @Injectable()
// export class TrainingsResolver implements Resolve<Observable<Training[] | void>> {

//     constructor(
//         private trainingService: TrainingService,
//         private store: Store<AppState>
//     ) { }


//     resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

//         return this.store.select(currentUser)
//             .pipe(
//                 take(1), 
//                 map((user: CurrentUser) => user.id),
//                 concatMap((userId: string) => {
//                     return this.getState(userId);
//                 }));
//     }

//     private getState(userId: string) {

//         return this.store
//             .select(trainings)
//             .pipe(
//                 take(1), 
//                 concatMap((trainings: Training[]) => {

//                 if (!trainings) {
//                     return this.updateState(userId);
//                 }
                        
//                 return of(trainings);
//             }));
//     }

//     private updateState(userId: string) {

//         return this.trainingService.getAll(userId)
//         .pipe(
//             take(1),
//             map(((trainings: Training[]) => {
//                 this.store.dispatch(trainingsFetched({trainings}));
//             }))
//         );
//     }
// }

