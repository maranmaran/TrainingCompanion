import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExerciseDetailsResolver } from 'src/business/resolvers/exercise-details.resolver';
import { TrainingDetailsResolver } from 'src/business/resolvers/training-details.resolver';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { ReportService } from 'src/business/services/feature-services/report.service';
import { SetService } from 'src/business/services/feature-services/set.service';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { TrainingEffects } from 'src/ngrx/training-log/training.effects';
import { trainingReducer } from 'src/ngrx/training-log/training.reducers';
import { ExerciseService } from './../../../business/services/feature-services/exercise.service';
import { ExerciseCreateEditComponent } from './exercise/exercise-create-edit/exercise-create-edit.component';
import { ExerciseDetailsComponent } from './exercise/exercise-details/exercise-details.component';
import { ExerciseListComponent } from './exercise/exercise-list/exercise-list.component';
import { SetCreateEditComponent } from './set/set-create-edit/set-create-edit.component';
import { SetListComponent } from './set/set-list/set-list.component';
import { TrainingLogHomeComponent } from './training-log-home/training-log-home.component';
import { TrainingLogRoutingModule } from './training-log-routing.module';
import { TrainingCreateEditComponent } from './training/training-create-edit/training-create-edit.component';
import { TrainingMediaComponent } from './training/training-details/panels/training-media/training-media.component';
import { TrainingMetricsComponent } from './training/training-details/panels/training-metrics/training-metrics.component';
import { TrainingNoteComponent } from './training/training-details/panels/training-note/training-note.component';
import { TrainingDetailsDataComponent } from './training/training-details/training-details-data/training-details-data.component';
import { TrainingDetailsComponent } from './training/training-details/training-details.component';
import { TrainingListComponent } from './training/training-list/training-list.component';
import { TrainingMonthComponent } from './training/training-month/training-month.component';


@NgModule({
    imports: [
        SharedModule,
        TrainingLogRoutingModule,
        // StoreModule.forFeature('trainingLogState', trainingLogReducerMap),
        StoreModule.forFeature('training', trainingReducer),
        EffectsModule.forFeature([TrainingEffects]),
    ],
    declarations: [
        TrainingLogHomeComponent,


        TrainingDetailsDataComponent,
        TrainingDetailsComponent,
        TrainingNoteComponent,
        TrainingMetricsComponent,
        TrainingMediaComponent,
        TrainingCreateEditComponent,
        TrainingListComponent,
        TrainingMonthComponent,

        ExerciseListComponent,
        ExerciseCreateEditComponent,
        ExerciseDetailsComponent,

        SetListComponent,
        SetCreateEditComponent,

    ],
    exports: [
    ],
    providers: [
        UIService,
        TrainingService,
        ExerciseService,
        ExerciseTypeService,
        SetService,
        ReportService,
        TrainingDetailsResolver,
        ExerciseDetailsResolver,
    ],
    entryComponents: [
        TrainingCreateEditComponent,
        ExerciseCreateEditComponent,
        SetCreateEditComponent
    ]
})
export class TrainingLogModule {}
