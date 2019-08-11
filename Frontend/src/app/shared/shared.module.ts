import { EnumToArrayPipe } from './../../business/pipes/enum-to-array.pipe';
import { ShowHidePasswordDirective } from 'src/business/directives/show-hide-password.directive';
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
import { MaterialTableComponent } from './material-table/material-table.component';
import { AthleteCreateEditComponent } from '../features/athlete-management/athletes-home/athlete-create-edit/athlete-create-edit.component';
import { AthletesService } from 'src/business/services/athletes.service';


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
        SanitizeHtmlPipe,
        EnumToArrayPipe,
        MaterialTableComponent,
        ShowHidePasswordDirective,
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
        SanitizeHtmlPipe,
        EnumToArrayPipe,
        MaterialTableComponent,
        ShowHidePasswordDirective
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
