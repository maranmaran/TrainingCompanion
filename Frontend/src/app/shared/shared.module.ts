import { ExerciseTypePreviewComponent } from './exercise-type-preview/exercise-type-preview.component';
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
import { EventCalendarComponent } from './event-calendar/event-calendar.component';
import { DynamicModule } from 'ng-dynamic-component';
import { ExerciseTypeChipComponent } from './exercise-type-preview/exercise-type-chip/exercise-type-chip.component';


@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        MaterialModule,
        
        //https://www.npmjs.com/package/ng-dynamic-component
        DynamicModule.withComponents([ExerciseTypePreviewComponent, ExerciseTypeChipComponent])
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
        EventCalendarComponent,
        ExerciseTypePreviewComponent,
        ExerciseTypeChipComponent
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
        ShowHidePasswordDirective,
        EventCalendarComponent,
        ExerciseTypePreviewComponent,
        ExerciseTypeChipComponent
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
