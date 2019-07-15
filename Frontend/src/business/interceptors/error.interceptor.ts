import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpRequest, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { ErrorService } from '../services/shared/error.service';
import { UIService } from '../services/shared/notification.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(
        private notificationService: UIService,
        private errorService: ErrorService
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        return next.handle(req)
            .pipe(
                catchError(
                    err => {
                        if(this.notificationService.showErrorSnackbar) {
                            this.errorService.handleError(err);
                            this.notificationService.setLoading(false);
                        }
                        
                        return throwError(err);
                    }
                )
            );;
    }
}

