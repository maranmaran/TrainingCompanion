import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { UIService } from 'src/business/services/shared/ui.service';
import { TrainingLogRoutingModule } from './training-log-routing.module';
import { TrainingLogHomeComponent } from './training-log-home/training-log-home.component';
import { TrainingCalendarComponent } from './training-lists/training-calendar/training-calendar.component';
import { trainingReducer } from 'src/ngrx/training/training.reducers';
import { TrainingEffects } from 'src/ngrx/training/training.effects';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { TrainingService } from 'src/business/services/training.service';
import { TrainingDetailsHomeComponent } from './training-details-home/training-details-home.component';
import { ExerciseListComponent } from './training-details-home/exercise-list/exercise-list.component';
import { ExerciseTypeService } from 'src/business/services/exercise-type.service';
import { ExerciseCreateEditComponent } from './training-details-home/exercise-list/exercise-create-edit/exercise-create-edit.component';
// import { TrainingsResolver } from 'src/business/resolvers/trainings.resolver';


@NgModule({
    imports: [
        SharedModule,
        TrainingLogRoutingModule,
        StoreModule.forFeature('training', trainingReducer),
        EffectsModule.forFeature([TrainingEffects]),
    ],
    declarations: [
        TrainingLogHomeComponent,
        TrainingCalendarComponent,
        TrainingDetailsHomeComponent,
        ExerciseListComponent,
        ExerciseCreateEditComponent,
    ],
    exports: [
    ],
    providers: [
        UIService,
        TrainingService,
        // TrainingsResolver
    ],
    entryComponents: [
        ExerciseCreateEditComponent
    ]
})
export class TrainingLogModule { }
