import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { UIService } from 'src/business/services/shared/ui.service';
import { TrainingLogRoutingModule } from './training-log-routing.module';
import { TrainingLogHomeComponent } from './training-log-home/training-log-home.component';
import { TrainingCalendarComponent } from './training/training-calendar/training-calendar.component';
import { trainingReducer } from 'src/ngrx/training/training.reducers';
import { TrainingEffects } from 'src/ngrx/training/training.effects';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { TrainingDetailsComponent } from './training/training-details/training-details.component';
// import { TrainingsResolver } from 'src/business/resolvers/trainings.resolver';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { ExerciseListComponent } from './exercise/exercise-list/exercise-list.component';
import { ExerciseCreateEditComponent } from './exercise/exercise-create-edit/exercise-create-edit.component';
import { ExerciseDetailsComponent } from './exercise/exercise-details/exercise-details.component';
import { SetListComponent } from './set/set-list/set-list.component';
import { SetCreateEditComponent } from './set/set-create-edit/set-create-edit.component';


@NgModule({
    imports: [
        SharedModule,
        TrainingLogRoutingModule,
        StoreModule.forFeature('training', trainingReducer),
        EffectsModule.forFeature([TrainingEffects]),
        AngularEditorModule 
    ],
    declarations: [
        TrainingLogHomeComponent,
        TrainingCalendarComponent,
        TrainingDetailsComponent,
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
        // TrainingsResolver
    ],
    entryComponents: [
        ExerciseCreateEditComponent,
        SetCreateEditComponent
    ]
})
export class TrainingLogModule { }
