import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { DynamicModule } from 'ng-dynamic-component';
import { AvatarModule } from 'ngx-avatar';
import { ButtonSizeDirective } from 'src/business/directives/button-size.directive';
import { ShowHidePasswordDirective } from 'src/business/directives/show-hide-password.directive';
import { ApplyTimezonePipe } from 'src/business/pipes/apply-timezone.pipe';
import { EnumToArrayPipe } from './../../business/pipes/enum-to-array.pipe';
import { SanitizeHtmlPipe } from './../../business/pipes/sanitize-html.pipe';
import { SplitPascalCasePipe } from './../../business/pipes/split-pascal-case.pipe';
import { TestCardComponent } from './../features/dashboard/dashboard-home/dashboard-card-container/card-components/test-card/test-card.component';
import { TrainingMonthViewDayComponent } from './../features/training-log/training/training-calendar/training-month/training-month-view-day/training-month-view-day.component';
import { NotificationItemComponent } from './/notifications/notification-item/notification-item.component';
import { NotificationTypeIconComponent } from './/notifications/notification-item/notification-type-icon/notification-type-icon.component';
import { MaterialModule } from './angular-material.module';
import { ChartCanvasDirective, ChartComponent } from './charts/chart/chart.component';
import { ActiveFlagComponent } from './custom-preview-components/active-flag/active-flag.component';
import { ExerciseTypeChipListComponent } from './custom-preview-components/exercise-type-preview/exercise-type-chip-list/exercise-type-chip-list.component';
import { ExerciseTypeChipComponent } from './custom-preview-components/exercise-type-preview/exercise-type-chip/exercise-type-chip.component';
import { ExerciseTypePreviewComponent } from './custom-preview-components/exercise-type-preview/exercise-type-preview.component';
import { NotImplementedComponent } from './custom-preview-components/not-implemented/not-implemented.component';
import { ConfirmDialogComponent } from './dialogs/confirm-dialog/confirm-dialog.component';
import { ErrorSnackbarComponent } from './dialogs/error-snackbar/error-snackbar.component';
import { MediaDialogComponent } from './dialogs/media-dialog/media-dialog.component';
import { MessageDialogComponent } from './dialogs/message-dialog/message-dialog.component';
import { CalendarMonthViewComponent } from './event-calendar/month-view/month-view.component';
import { CalendarWeekViewComponent } from './event-calendar/week-view/week-view.component';
import { MaterialTableComponent } from './material-table/material-table.component';
import { MediaContainerComponent } from './media/media-container/media-container.component';
import { MediaListComponent } from './media/media-uploader/media-list/media-list.component';
import { MediaUploaderComponent } from './media/media-uploader/media-uploader.component';
import { UploadInputComponent } from './media/media-uploader/upload-input/upload-input.component';


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
        TestCardComponent,
        ApplyTimezonePipe,
        ButtonSizeDirective
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
        TestCardComponent,
        ApplyTimezonePipe,
        ButtonSizeDirective
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
