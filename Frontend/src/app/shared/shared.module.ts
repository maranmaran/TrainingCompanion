import { SanitizeHtmlPipe } from './../../business/pipes/sanitize-html.pipe';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from './angular-material.module';
import { MediaDialogComponent } from './media-dialog/media-dialog.component';
import { ErrorSnackbarComponent } from './error-snackbar/error-snackbar.component';
import { MessageDialogComponent } from './message-dialog/message-dialog.component';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';


@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        MaterialModule,
    ],
    declarations: [
        MediaDialogComponent,
        ErrorSnackbarComponent,
        MessageDialogComponent,
        ConfirmDialogComponent,
        SanitizeHtmlPipe
    ],
    exports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        MaterialModule,

        MediaDialogComponent,
        ErrorSnackbarComponent,
        MessageDialogComponent,
        ConfirmDialogComponent,
        SanitizeHtmlPipe
    ],
    providers: [
    ],
    entryComponents: [
        MediaDialogComponent,
        ErrorSnackbarComponent,
        MessageDialogComponent,
        ConfirmDialogComponent,
    ]
})
export class SharedModule { }
