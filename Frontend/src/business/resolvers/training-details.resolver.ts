import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { catchError, concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { exercisePrsFetched, setSelectedExercise, setSelectedTraining, trainingsFetched } from 'src/ngrx/training-log/training.actions';
import { selectedTraining, selectedTrainingId } from 'src/ngrx/training-log/training.selectors';
import { Training } from 'src/server-models/entities/training.model';
import { TrainingService } from '../services/feature-services/training.service';
import { LocalStorageKeys } from '../shared/localstorage.keys.enum';
import { PersonalBestService } from './../services/feature-services/personal-best.service';

@Injectable()
export class TrainingDetailsResolver implements Resolve<Observable<Training> | Observable<unknown>> {

    constructor(
        private trainingService: TrainingService,
        private store: Store<AppState>,
        private router: Router,
        private prService: PersonalBestService
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        return this.store.select(selectedTrainingId)
            .pipe(
                take(1),
                concatMap((id: string) => {
                    if (!id) {
                        id = localStorage.getItem(LocalStorageKeys.trainingId);

                        if (!id) {
                            this.router.navigate(['/app/training-log'])
                            return of();
                        }

                        return this.getState(id);
                    }

                    return this.store.select(selectedTraining).pipe(take(1));
                }));
    }

    private getState(id: string) {

        return this.trainingService.getOne(id)
            .pipe(
                take(1),
                map(((training: Training) => {
                    this.store.dispatch(trainingsFetched({ entities: [training] }));
                    this.store.dispatch(setSelectedTraining({ entity: training }));

                    let exerciseId = localStorage.getItem(LocalStorageKeys.exerciseId);
                    if (exerciseId) {
                        let exercise = training.exercises.filter(x => x.id == exerciseId)[0];
                        this.store.dispatch(setSelectedExercise({ entity: exercise }));

                        this.prService.get(exercise.exerciseType.id)
                        .pipe(take(1), catchError(_ => []))
                        .subscribe(prs => this.store.dispatch(exercisePrsFetched({prs})))
                    }

                    return training;
                }))
            );
    }
}
