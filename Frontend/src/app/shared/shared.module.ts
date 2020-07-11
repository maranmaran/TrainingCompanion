import { CommonModule } from '@angular/common';
import { HttpBackend } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { NguCarouselModule } from '@ngu/carousel';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { DynamicModule } from 'ng-dynamic-component';
import { AvatarModule } from 'ngx-avatar';
import { ImageCropperModule } from 'ngx-image-cropper';
import { HttpLoaderFactory } from 'src/assets/i18n/translation-http-loader.factory';
import { ButtonSizeDirective } from 'src/business/directives/button-size.directive';
import { ShowHidePasswordDirective } from 'src/business/directives/show-hide-password.directive';
import { ApplyTimezonePipe } from 'src/business/pipes/apply-timezone.pipe';
import { FormatMomentDatePipe } from 'src/business/pipes/format-moment-date.pipe';
import { RepeatPipe } from 'src/business/pipes/repeat.pipe';
import { TransformRpePipe } from 'src/business/pipes/transform-rpe.pipe';
import { MaxCardComponent } from '../features/dashboard/dashboard-home/tracks/card-components/max-card/max-card.component';
import { VolumeCardComponent } from '../features/dashboard/dashboard-home/tracks/card-components/volume-card/volume-card.component';
import { ShowUnitSystemLabelPipe } from './../../business/pipes/convert-unit-system.pipe';
import { EnumToArrayPipe } from './../../business/pipes/enum-to-array.pipe';
import { SanitizeHtmlPipe } from './../../business/pipes/sanitize-html.pipe';
import { SplitPascalCasePipe } from './../../business/pipes/split-pascal-case.pipe';
import { TransformWeightPipe } from './../../business/pipes/transform-weight.pipe';
import { TrainingMonthViewDayComponent } from './../features/training-log/training/training-month/training-month-view-day/training-month-view-day.component';
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
import { ImageCropperComponent } from './media/image-cropper/image-cropper.component';
import { MediaCarouselComponent } from './media/media-carousel/media-carousel.component';
import { MediaContainerComponent } from './media/media-container/media-container.component';
import { MediaListComponent } from './media/media-uploader/media-list/media-list.component';
import { MediaUploaderComponent } from './media/media-uploader/media-uploader.component';
import { UploadInputComponent } from './media/media-uploader/upload-input/upload-input.component';
import { BodyweightNotificationBodyComponent } from './notifications/notification-item/body-templates/bodyweight-notification-body.component';
import { ImportNotificationBodyComponent } from './notifications/notification-item/body-templates/import-notification-body.component';
import { MediaNotificationBodyComponent } from './notifications/notification-item/body-templates/media-notification-body.component';
import { NoteNotificationBodyComponent } from './notifications/notification-item/body-templates/note-notification-body.component';
import { PersonalBestNotificationBodyComponent } from './notifications/notification-item/body-templates/personal-best-notification-body.component';
import { TrainingNotificationBodyComponent } from './notifications/notification-item/body-templates/training-notification-body.component';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        MaterialModule,
        CKEditorModule,

        // https://www.npmjs.com/package/ng-dynamic-component
        DynamicModule,
        AvatarModule,
        ImageCropperModule,
        // lazy loaded modules import of translate module
        // https://github.com/ngx-translate/core#1-import-the-translatemodule
        TranslateModule.forChild({
            isolate: false,
            extend: true,
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [HttpBackend]
            }
        }),
        NguCarouselModule
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
        ApplyTimezonePipe,
        ButtonSizeDirective,
        TransformWeightPipe,
        TransformRpePipe,
        ShowUnitSystemLabelPipe,
        ImageCropperComponent,
        VolumeCardComponent,
        MaxCardComponent,
        MediaNotificationBodyComponent,
        BodyweightNotificationBodyComponent,
        TrainingNotificationBodyComponent,
        NoteNotificationBodyComponent,
        PersonalBestNotificationBodyComponent,
        ImportNotificationBodyComponent,
        RepeatPipe,
        FormatMomentDatePipe,
        MediaCarouselComponent
    ],
    exports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule,
        MaterialModule,
        CKEditorModule,
        // export translate module to
        // others who use it
        // https://github.com/ngx-translate/core#1-import-the-translatemodule
        TranslateModule,

        DynamicModule,

        AvatarModule,
        MediaDialogComponent,
        ErrorSnackbarComponent,
        MessageDialogComponent,
        ConfirmDialogComponent,
        SanitizeHtmlPipe,
        EnumToArrayPipe,
        SplitPascalCasePipe,
        ShowUnitSystemLabelPipe,
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
        VolumeCardComponent,
        MaxCardComponent,
        ApplyTimezonePipe,
        ButtonSizeDirective,
        TransformWeightPipe,
        TransformRpePipe,
        ImageCropperModule,
        ImageCropperComponent,
        MediaNotificationBodyComponent,
        BodyweightNotificationBodyComponent,
        TrainingNotificationBodyComponent,
        NoteNotificationBodyComponent,
        PersonalBestNotificationBodyComponent,
        ImportNotificationBodyComponent,
        RepeatPipe,
        MediaCarouselComponent,
        FormatMomentDatePipe
    ],
    providers: [
    ],
    entryComponents: [
        // TODO remove after ~30 days - 09.07.20
        // MediaDialogComponent,
        // ErrorSnackbarComponent,
        // MessageDialogComponent,
        // ConfirmDialogComponent,
    ]
})
export class SharedModule { }
