import { HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs/internal/Observable';
import { finalize } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { httpRequestStartLoading, httpRequestStopLoading } from 'src/ngrx/user-interface/ui.actions';
import { AppSettingsService } from '../services/shared/app-settings.service';

@Injectable()
export class HttpInterceptor implements HttpInterceptor {

    constructor(
        private appSettingsService: AppSettingsService,
        private store: Store<AppState>
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        this.store.dispatch(httpRequestStartLoading());

        req = req.clone({
            url: this.appSettingsService.apiUrl + req.url,
            withCredentials: true,
            // headers: this.appSettingsService.apiHeaders
        });


        return next.handle(req)
            .pipe(
                finalize(() => this.store.dispatch(httpRequestStopLoading()))
            );
    }
}
