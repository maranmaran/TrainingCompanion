import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { DynamicModule } from 'ng-dynamic-component';
import { AvatarModule } from 'ngx-avatar';
import { ShowHidePasswordDirective } from 'src/business/directives/show-hide-password.directive';
import { EnumToArrayPipe } from './../../business/pipes/enum-to-array.pipe';
import { SanitizeHtmlPipe } from './../../business/pipes/sanitize-html.pipe';
import { SplitPascalCasePipe } from './../../business/pipes/split-pascal-case.pipe';
import { TestCardComponent } from './../features/dashboard/dashboard-home/dashboard-card-container/card-components/test-card/test-card.component';
import { TrainingMonthViewDayComponent } from './../features/training-log/training/training-calendar/training-month/training-month-view-day/training-month-view-day.component';
import { ActiveFlagComponent } from './active-flag/active-flag.component';
import { MaterialModule } from './angular-material.module';
import { ChartCanvasDirective, ChartComponent } from './charts/chart/chart.component';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { ErrorSnackbarComponent } from './error-snackbar/error-snackbar.component';
import { CalendarMonthViewComponent } from './event-calendar/month-view/month-view.component';
import { CalendarWeekViewComponent } from './event-calendar/week-view/week-view.component';
import { ExerciseTypeChipListComponent } from './exercise-type-preview/exercise-type-chip-list/exercise-type-chip-list.component';
import { ExerciseTypeChipComponent } from './exercise-type-preview/exercise-type-chip/exercise-type-chip.component';
import { ExerciseTypePreviewComponent } from './exercise-type-preview/exercise-type-preview.component';
import { MaterialTableComponent } from './material-table/material-table.component';
import { MediaContainerComponent } from './media-container/media-container.component';
import { MediaDialogComponent } from './media-dialog/media-dialog.component';
import { MediaListComponent } from './media-uploader/media-list/media-list.component';
import { MediaUploaderComponent } from './media-uploader/media-uploader.component';
import { UploadInputComponent } from './media-uploader/upload-input/upload-input.component';
import { MessageDialogComponent } from './message-dialog/message-dialog.component';
import { NotImplementedComponent } from './not-implemented/not-implemented.component';
import { NotificationItemComponent } from './notification-item/notification-item.component';
import { NotificationTypeIconComponent } from './notification-item/notification-type-icon/notification-type-icon.component';


@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        MaterialModule,
        CKEditorModule,

        // https://www.npmjs.com/package/ng-dynamic-component
        DynamicModule.withComponents([
            ExerciseTypePreviewComponent,
            ExerciseTypeChipComponent,
            ExerciseTypeChipListComponent,
            ActiveFlagComponent,
            TrainingMonthViewDayComponent,
            TestCardComponent,
        ]),
        AvatarModule,
    ],
    declarations: [
        MediaDialogComponent,
        ErrorSnackbarComponent,
        MessageDialogComponent,
        ConfirmDialogComponent,
        SanitizeHtmlPipe,
        EnumToArrayPipe,
        SplitPascalCasePipe,
        MaterialTableComponent,
        ShowHidePasswordDirective,
        ChartCanvasDirective,
        CalendarMonthViewComponent,
        CalendarWeekViewComponent,
        ExerciseTypePreviewComponent,
        ExerciseTypeChipComponent,
        ExerciseTypeChipListComponent,
        ActiveFlagComponent,
        MediaContainerComponent,
        NotImplementedComponent,
        MediaListComponent,
        UploadInputComponent,
        MediaUploaderComponent,
        NotificationItemComponent,
        TrainingMonthViewDayComponent,
        ChartComponent,
        NotificationTypeIconComponent,
        TestCardComponent
    ],
    exports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        MaterialModule,
        CKEditorModule,

        DynamicModule,

        AvatarModule,
        MediaDialogComponent,
        ErrorSnackbarComponent,
        MessageDialogComponent,
        ConfirmDialogComponent,
        SanitizeHtmlPipe,
        EnumToArrayPipe,
        SplitPascalCasePipe,
        MaterialTableComponent,
        ShowHidePasswordDirective,
        ChartCanvasDirective,
        CalendarMonthViewComponent,
        CalendarWeekViewComponent,
        ExerciseTypePreviewComponent,
        ExerciseTypeChipComponent,
        ActiveFlagComponent,
        ExerciseTypeChipListComponent,
        MediaContainerComponent,
        NotImplementedComponent,
        MediaListComponent,
        UploadInputComponent,
        MediaUploaderComponent,
        NotificationItemComponent,
        TrainingMonthViewDayComponent,
        ChartComponent,
        NotificationTypeIconComponent,
        TestCardComponent
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
