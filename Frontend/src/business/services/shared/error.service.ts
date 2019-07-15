import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorSnackbarComponent } from 'src/app/shared/error-snackbar/error-snackbar.component';
import { UIService } from '../shared/notification.service';

@Injectable({ providedIn: 'root'})
export class ErrorService {

    constructor(
        private notificationService: UIService
    ) { }

    public handleError(err: HttpErrorResponse) {
        this.notificationService.openFromComponent(ErrorSnackbarComponent, { data: err, duration: 2000});
    }
}