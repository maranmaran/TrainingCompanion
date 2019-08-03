import { HttpErrorResponse } from '@angular/common/http';
import { ErrorSnackbarComponent } from 'src/app/shared/error-snackbar/error-snackbar.component';
import { UIService } from './ui.service';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ErrorService {

    constructor(
        private UIService: UIService
    ) {
    }

    public handleError(err: HttpErrorResponse) {
        this.UIService.openSnackbarFromComponent(ErrorSnackbarComponent, { data: err, duration: 2000});
    }
}