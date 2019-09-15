import { NgModule } from '@angular/core';
// import { TrainingsResolver } from 'src/business/resolvers/trainings.resolver';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { TrainingDetailsResolver } from 'src/business/resolvers/training-details.resolver';
import { SetService } from 'src/business/services/feature-services/set.service';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ExerciseEffects } from 'src/ngrx/training-log/exercise/exercise.effects';
import { SetEffects } from 'src/ngrx/training-log/set/set.effects';
import { trainingLogReducerMap } from 'src/ngrx/training-log/training-log.state';
import { TrainingEffects } from 'src/ngrx/training-log/training/training.effects';
import { ExerciseService } from './../../../business/services/feature-services/exercise.service';
import { ExerciseCreateEditComponent } from './exercise/exercise-create-edit/exercise-create-edit.component';
import { ExerciseDetailsComponent } from './exercise/exercise-details/exercise-details.component';
import { ExerciseListComponent } from './exercise/exercise-list/exercise-list.component';
import { SetCreateEditComponent } from './set/set-create-edit/set-create-edit.component';
import { SetListComponent } from './set/set-list/set-list.component';
import { TrainingLogHomeComponent } from './training-log-home/training-log-home.component';
import { TrainingLogRoutingModule } from './training-log-routing.module';
import { TrainingCalendarComponent } from './training/training-calendar/training-calendar.component';
import { TrainingDetailsComponent } from './training/training-details/training-details.component';


@NgModule({
    imports: [
        SharedModule,
        TrainingLogRoutingModule,
        StoreModule.forFeature('trainingLogState', trainingLogReducerMap),
        EffectsModule.forFeature([TrainingEffects, ExerciseEffects, SetEffects]),
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
        ExerciseService,
        SetService,
        TrainingDetailsResolver
    ],
    entryComponents: [
        ExerciseCreateEditComponent,
        SetCreateEditComponent
    ]
})
export class TrainingLogModule { }
