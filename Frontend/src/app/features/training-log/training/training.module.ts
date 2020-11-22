import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { TrainingDetailsResolver } from 'src/business/resolvers/training-details.resolver';
import { TrainingMediaResolver } from 'src/business/resolvers/training-media.resolver';
import { TrainingExercisesResolver } from 'src/business/resolvers/training-exercise.resolver';
import { ReportService } from 'src/business/services/feature-services/report.service';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ExerciseModule } from './../exercise/exercise.module';
import { TrainingCreateEditComponent } from './training-create-edit/training-create-edit.component';
import { TrainingMediaComponent } from './training-details/panels/training-media/training-media.component';
import { TrainingMetricsComponent } from './training-details/panels/training-metrics/training-metrics.component';
import { TrainingNoteComponent } from './training-details/panels/training-note/training-note.component';
import { TrainingDetailsDataComponent } from './training-details/training-details-data/training-details-data.component';
import { TrainingDetailsComponent } from './training-details/training-details.component';
import { TrainingListComponent } from './training-list/training-list.component';
import { TrainingMonthComponent } from './training-month/training-month.component';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { TrainingEffects } from 'src/ngrx/training-log/training.effects';
import { trainingReducer } from 'src/ngrx/training-log/training.reducers';
import { TrainingMetricsResolver } from 'src/business/resolvers/training-metrics.resolver';
import { TrainingMonthResolver } from 'src/business/resolvers/training-month.resolver';


@NgModule({
  imports: [
      SharedModule,
      ExerciseModule,
  ],
  declarations: [
      TrainingDetailsDataComponent,
      TrainingDetailsComponent,
      TrainingNoteComponent,
      TrainingMetricsComponent,
      TrainingMediaComponent,
      TrainingCreateEditComponent,
      TrainingListComponent,
      TrainingMonthComponent,
  ],
  exports: [
      TrainingListComponent,
  ],
  providers: [
      UIService,
      TrainingService,
      ReportService,
      TrainingDetailsResolver,
      TrainingExercisesResolver,
      TrainingMediaResolver,
      TrainingMetricsResolver,
      TrainingMonthResolver 
  ],
  entryComponents: [
  ]
})
export class TrainingModule {}
