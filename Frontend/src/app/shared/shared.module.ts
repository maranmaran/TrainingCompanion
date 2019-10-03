import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DynamicModule } from 'ng-dynamic-component';
import { ShowHidePasswordDirective } from 'src/business/directives/show-hide-password.directive';
import { EnumToArrayPipe } from './../../business/pipes/enum-to-array.pipe';
import { SanitizeHtmlPipe } from './../../business/pipes/sanitize-html.pipe';
import { ActiveFlagComponent } from './active-flag/active-flag.component';
import { MaterialModule } from './angular-material.module';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { ErrorSnackbarComponent } from './error-snackbar/error-snackbar.component';
import { EventCalendarComponent } from './event-calendar/event-calendar.component';
import { ExerciseTypeChipListComponent } from './exercise-type-preview/exercise-type-chip-list/exercise-type-chip-list.component';
import { ExerciseTypeChipComponent } from './exercise-type-preview/exercise-type-chip/exercise-type-chip.component';
import { ExerciseTypePreviewComponent } from './exercise-type-preview/exercise-type-preview.component';
import { MaterialTableComponent } from './material-table/material-table.component';
import { MediaContainerComponent } from './media-container/media-container.component';
import { MediaDialogComponent } from './media-dialog/media-dialog.component';
import { MessageDialogComponent } from './message-dialog/message-dialog.component';
import { NotImplementedComponent } from './not-implemented/not-implemented.component';


@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        MaterialModule,

        //https://www.npmjs.com/package/ng-dynamic-component
        DynamicModule.withComponents([ExerciseTypePreviewComponent, ExerciseTypeChipComponent, ExerciseTypeChipListComponent, ActiveFlagComponent])
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
        ExerciseTypeChipComponent,
        ExerciseTypeChipListComponent,
        ActiveFlagComponent,
        MediaContainerComponent,
        NotImplementedComponent
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
        ExerciseTypeChipComponent,
        ActiveFlagComponent,
        ExerciseTypeChipListComponent,
        MediaContainerComponent,
        NotImplementedComponent
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
