import { UIService } from './../services/shared/notification.service';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { AppSettingsService } from '../services/shared/app-settings.service';
import { finalize } from 'rxjs/operators';

@Injectable()
export class HttpInterceptor implements HttpInterceptor {

    constructor(
        private appSettingsService: AppSettingsService,
        private notificationService: UIService
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      
        this.notificationService.setLoading(true);

        req = req.clone({
            url: this.appSettingsService.apiUrl + req.url,
            withCredentials: true,
            // headers: this.appSettingsService.apiHeaders
        });

        return next.handle(req)
            .pipe(
                finalize(() => this.notificationService.setLoading(false))
            );
    }
}

