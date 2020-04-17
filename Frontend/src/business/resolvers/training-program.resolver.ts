import { Injectable } from '@angular/core'; import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router'; import { Observable, of } from 'rxjs'; import { TrainingProgram } from 'src/server-models/entities/training-program.model'; import { Store } from '@ngrx/store'; import { AppState } from 'src/ngrx/global-setup.ngrx'; import { currentUser } from 'src/ngrx/auth/auth.selectors'; import { take, map, concatMap } from 'rxjs/operators'; import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response'; import { trainingPrograms } from 'src/ngrx/training-program/training-program.selectors'; import { trainingProgramFetched } from 'src/ngrx/training-program/training-program.actions';
import { isEmpty } from '../utils/utils';
import { TrainingProgramService } from '../services/feature-services/training-program.service';


@Injectable()
export class TrainingProgramsResolver implements Resolve<Observable<TrainingProgram[] | void>> {

    constructor(
        private trainingProgramService: TrainingProgramService,
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
            .select(trainingPrograms)
            .pipe(
                take(1),
                concatMap((programs: TrainingProgram[]) => {

                    if (isEmpty(programs)) {
                        return this.updateState(userId);
                    }

                    return of(programs);
                }));
    }

    private updateState(userId: string) {

        return this.trainingProgramService.getAll(userId)
            .pipe(
                take(1),
                map((entities: TrainingProgram[]) => {
                    this.store.dispatch(trainingProgramFetched({ entities }));
                }))
    }
}
