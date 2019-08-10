import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { throwError } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { catchError } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { httpErrorOccured } from 'src/ngrx/user-interface/ui.actions';
import { ErrorDetails } from 'src/server-models/error/error-details.model';
import { ServerStatusCodes } from 'src/server-models/error/status-codes/server.codes';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(
        private store: Store<AppState>
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        return next.handle(req)
            .pipe(
                catchError((error: HttpErrorResponse) => {

                    const serverError = error.error as ErrorDetails;
                    
                    if(serverError.Status = ServerStatusCodes.InternalServerError) {
                        this.store.dispatch(httpErrorOccured(serverError.Message))
                    }

                    return throwError(error);
                }),
            );;
    }
}

