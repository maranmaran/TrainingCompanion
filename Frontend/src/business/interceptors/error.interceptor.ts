import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpRequest, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { catchError, concatMap, take, finalize } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { ErrorService } from '../services/shared/error.service';
import { UIService } from '../services/shared/ui.service';
import { Store } from '@ngrx/store';
import { showErrorSnackbar } from 'src/ngrx/user-interface/ui.selectors';
import { httpRequestStartLoading, httpRequestStopLoading, httpErrorOccured } from 'src/ngrx/user-interface/ui.actions';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(
        private UIService: UIService,
        private errorService: ErrorService,
        private store: Store<AppState>
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        return next.handle(req)
            .pipe(
                catchError(errorMessage => {

                    // // only handle error with snackbar if you are allowed to
                    // this.store.select(showErrorSnackbar)
                    //     .pipe(take(1))
                    //     .subscribe(
                    //         (showErrorSnackbar: boolean) => {
                    //             if (showErrorSnackbar) {
                    //                 this.errorService.handleError(err); // action.. effect ?
                    //                 // this.UIService.setLoading(false);
                    //             }
                    //         }
                    //     )

                    this.store.dispatch(httpErrorOccured(errorMessage))
                    return throwError(errorMessage);
                }),

                finalize(() => this.store.dispatch(httpRequestStopLoading)), // stop progress bars
            );;
    }
}

