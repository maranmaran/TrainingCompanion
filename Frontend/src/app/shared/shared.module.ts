import { ErrorSnackbarComponent } from './error-snackbar/error-snackbar.component';
import { MessageDialogComponent } from './message-dialog/message-dialog.component';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { MaterialModule } from './angular-material.module';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        MaterialModule
    ],
    declarations: [
        ConfirmDialogComponent,
        MessageDialogComponent,
        ErrorSnackbarComponent
    ],
    exports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        MaterialModule,
    ],
    providers: [
    ],
    entryComponents: [
        ConfirmDialogComponent,
        MessageDialogComponent,
        ErrorSnackbarComponent
    ]
})
export class SharedModule { }
