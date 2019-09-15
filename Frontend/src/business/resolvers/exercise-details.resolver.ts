import { LocalStorageKeys } from './../shared/localstorage.keys.enum';
import { ExerciseService } from '../services/feature-services/exercise.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Exercise } from 'src/server-models/entities/exercise.model';

// @Injectable()
// export class ExerciseDetailsResolver implements Resolve<Observable<Exercise | void>> {

//     constructor(
//         private exerciseService: ExerciseService,
//         private store: Store<AppState>
//     ) { }


//     resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

//         return this.store.select(selectedExerciseId)
//             .pipe(
//                 take(1), 
//                 concatMap((id: string) => {
//                     if(!id) {
//                         id = localStorage.getItem(LocalStorageKeys.exerciseId);
//                         this.getState(id);
//                     } 

//                     return this.store.select(selectedExercise);
//                 }));
//     }

//     private getState(id: string) {

//         return this.exerciseService.getOne(id)
//         .pipe(
//             take(1),
//             map(((exercise: Exercise) => {
//                 this.store.dispatch(exercisesFetched({exercises: [exercise]}));
//                 this.store.dispatch(setSelectedExercise({exercise}));

//                 return exercise;
//             }))
//         );
//     }
// }

