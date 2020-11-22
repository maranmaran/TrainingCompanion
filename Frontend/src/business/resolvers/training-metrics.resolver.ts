import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { combineLatest, Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { ReportService } from 'src/business/services/feature-services/report.service';
import { LocalStorageKeys } from 'src/business/shared/localstorage.keys.enum';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setTrainingMetrics } from 'src/ngrx/training-log/training.actions';
import { selectedTrainingId, trainingMetricsDict } from 'src/ngrx/training-log/training.selectors';
import { GetTrainingMetricsResponse } from 'src/server-models/cqrs/report/get-training-metrics.response';
import { Training } from 'src/server-models/entities/training.model';

@Injectable()
export class TrainingMetricsResolver implements Resolve<Observable<Training> | Observable<unknown>> {

    constructor(
        private reportService: ReportService,
        private store: Store<AppState>,
        private router: Router,
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        return combineLatest([
                this.store.select(selectedTrainingId),
                this.store.select(currentUserId),
                this.store.select(trainingMetricsDict)
            ])
            .pipe(
                take(1),
                concatMap(([id, userId, data]) => {

                    // Training selected
                    if (id) {

                        // if data exists.. return it otherwise fetch new
                        return data ? of(data) : this.getState(id as string, userId);
                    }

                    // probably refresh
                    id = localStorage.getItem(LocalStorageKeys.trainingId);

                    // either reroute back
                    if (!id) {
                        return of(this.router.navigate(['/app/training-log']))
                    }

                    // or fetch data again
                    return this.getState(id, userId);
                }));
    }

    private getState(id: string, userId) {

        return this.reportService.getTrainingMetrics(id as string, userId)
            .pipe(
                take(1),
                map((metrics => {
                    this.store.dispatch(setTrainingMetrics({ id, metrics: metrics as GetTrainingMetricsResponse }));
                    return metrics;
                }))
            );
    }
}