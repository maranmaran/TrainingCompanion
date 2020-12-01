import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { TrainingProgramsResolver } from 'src/business/resolvers/training-program.resolver';
import { TrainingBlockDayService } from 'src/business/services/feature-services/training-block-day.service';
import { TrainingBlockService } from 'src/business/services/feature-services/training-block.service';
import { TrainingProgramUserService } from 'src/business/services/feature-services/training-program-user.service';
import { TrainingProgramService } from 'src/business/services/feature-services/training-program.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { TrainingProgramEffects } from 'src/ngrx/training-program/training-program/training-program.effects';
import { trainingProgramReducer } from 'src/ngrx/training-program/training-program/training-program.reducers';
import { TrainingBlockDayEffects } from './../../../ngrx/training-program/training-block-day/training-block-day.effects';
import { trainingBlockDayReducer } from './../../../ngrx/training-program/training-block-day/training-block-day.reducers';
import { TrainingBlockEffects } from './../../../ngrx/training-program/training-block/training-block.effects';
import { trainingBlockReducer } from './../../../ngrx/training-program/training-block/training-block.reducers';
import { TrainingProgramUserEffects } from './../../../ngrx/training-program/training-program-user/training-program-user.effects';
import { trainingProgramUserReducer } from './../../../ngrx/training-program/training-program-user/training-program-user.reducers';
import { ExerciseModule } from './../training-log/exercise/exercise.module';
import { SetModule } from './../training-log/set/set.module';
import { TrainingModule } from './../training-log/training/training.module';
import { TrainingBlockCreateEditComponent } from './training-program-home/training-block-components/training-block-create-edit/training-block-create-edit.component';
import { TrainingBlockListComponent } from './training-program-home/training-block-components/training-block-list/training-block-list.component';
import { TrainingProgramAssignComponent } from './training-program-home/training-program-components/training-program-assign/training-program-assign.component';
import { TrainingProgramCreateEditComponent } from './training-program-home/training-program-components/training-program-create-edit/training-program-create-edit.component';
import { AssignedAthletesComponent } from './training-program-home/training-program-components/training-program-details/assigned-athletes/assigned-athletes.component';
import { BasicDetailsComponent } from './training-program-home/training-program-components/training-program-details/basic-details/basic-details.component';
import { ProgramMetricsComponent } from './training-program-home/training-program-components/training-program-details/program-metrics/program-metrics.component';
import { TrainingProgramDetailsComponent } from './training-program-home/training-program-components/training-program-details/training-program-details.component';
import { TrainingProgramListComponent } from './training-program-home/training-program-components/training-program-list/training-program-list.component';
import { TrainingProgramHomeComponent } from './training-program-home/training-program-home.component';
import { BlockDayComponent } from './training-program-home/workout-filler/block-day/block-day.component';
import { BlockExerciseCreateEditComponent } from './training-program-home/workout-filler/block-day/block-training/block-exercise-create-edit/block-exercise-create-edit.component';
import { BlockTrainingCreateEditComponent } from './training-program-home/workout-filler/block-day/block-training/block-training-create-edit/block-training-create-edit.component';
import { BlockExerciseDetailsComponent } from './training-program-home/workout-filler/block-day/block-training/block-exercise-details/block-exercise-details.component';
import { BlockTrainingComponent } from './training-program-home/workout-filler/block-day/block-training/block-training.component';
import { WorkoutFillerComponent } from './training-program-home/workout-filler/workout-filler.component';
import { TrainingProgramRoutingModule } from './training-program-routing.module';

@NgModule({
    imports: [
        SharedModule,
        TrainingProgramRoutingModule,
        StoreModule.forFeature('trainingPrograms', trainingProgramReducer),
        StoreModule.forFeature('trainingBlocks', trainingBlockReducer),
        StoreModule.forFeature('trainingBlockDays', trainingBlockDayReducer),
        StoreModule.forFeature('trainingProgramUsers', trainingProgramUserReducer),
        EffectsModule.forFeature([TrainingProgramEffects, TrainingBlockEffects, TrainingBlockDayEffects, TrainingProgramUserEffects]),
        FormsModule,
        TrainingModule,
        ExerciseModule,
        SetModule,
    ],
    declarations: [
        TrainingProgramHomeComponent,

        TrainingProgramListComponent,
        TrainingProgramCreateEditComponent,
        TrainingProgramDetailsComponent,
        BasicDetailsComponent,
        AssignedAthletesComponent,
        ProgramMetricsComponent,
        TrainingProgramAssignComponent,

        TrainingBlockListComponent,
        TrainingBlockCreateEditComponent,

        WorkoutFillerComponent,
        BlockDayComponent,
        
        BlockTrainingComponent,
        BlockTrainingCreateEditComponent,

        BlockExerciseCreateEditComponent,
        BlockExerciseDetailsComponent,
    ],
    exports: [
    ],
    providers: [
        TrainingProgramService,
        TrainingProgramsResolver,

        TrainingBlockService,
        TrainingBlockDayService,

        TrainingProgramUserService,

        UIService
    ],
    entryComponents: [
    ]
})
export class TrainingProgramModule { }
