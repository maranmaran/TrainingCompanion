import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { TrainingProgramsResolver } from 'src/business/resolvers/training-program.resolver';
import { TrainingBlockDayService } from 'src/business/services/feature-services/training-block-day.service';
import { TrainingBlockService } from 'src/business/services/feature-services/training-block.service';
import { TrainingProgramService } from 'src/business/services/feature-services/training-program.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { TrainingProgramEffects } from 'src/ngrx/training-program/training-program/training-program.effects';
import { trainingProgramReducer } from 'src/ngrx/training-program/training-program/training-program.reducers';
import { trainingBlockDayReducer } from './../../../ngrx/training-program/training-block-day/training-block-day.reducers';
import { trainingBlockReducer } from './../../../ngrx/training-program/training-block/training-block.reducers';
import { BlockExerciseCreateEditComponent } from './training-program-home/block-exercise-components/block-exercise-create-edit/block-exercise-create-edit.component';
import { BlockExerciseListComponent } from './training-program-home/block-exercise-components/block-exercise-list/block-exercise-list.component';
import { BlockSetsCreateEditComponent } from './training-program-home/block-sets-components/block-sets-create-edit/block-sets-create-edit.component';
import { BlockSetsListComponent } from './training-program-home/block-sets-components/block-sets-list/block-sets-list.component';
import { BlockTrainingCreateEditComponent } from './training-program-home/block-training-components/block-training-create-edit/block-training-create-edit.component';
import { BlockTrainingDetailsComponent } from './training-program-home/block-training-components/block-training-details/block-training-details.component';
import { BlockTrainingListComponent } from './training-program-home/block-training-components/block-training-list/block-training-list.component';
import { TrainingBlockCreateEditComponent } from './training-program-home/training-block-components/training-block-create-edit/training-block-create-edit.component';
import { TrainingBlockDetailsComponent } from './training-program-home/training-block-components/training-block-details/training-block-details.component';
import { TrainingBlockListComponent } from './training-program-home/training-block-components/training-block-list/training-block-list.component';
import { TrainingBlockDayCreateEditComponent } from './training-program-home/training-block-day-components/training-block-day-create-edit/training-block-day-create-edit.component';
import { TrainingBlockDayListComponent } from './training-program-home/training-block-day-components/training-block-day-list/training-block-day-list.component';
import { TrainingProgramCreateEditComponent } from './training-program-home/training-program-components/training-program-create-edit/training-program-create-edit.component';
import { TrainingProgramDetailsComponent } from './training-program-home/training-program-components/training-program-details/training-program-details.component';
import { TrainingProgramListComponent } from './training-program-home/training-program-components/training-program-list/training-program-list.component';
import { TrainingProgramHomeComponent } from './training-program-home/training-program-home.component';
import { TrainingProgramRoutingModule } from './training-program-routing.module';

@NgModule({
    imports: [
        SharedModule,
        TrainingProgramRoutingModule,
        StoreModule.forFeature('trainingPrograms', trainingProgramReducer),
        StoreModule.forFeature('trainingBlocks', trainingBlockReducer),
        StoreModule.forFeature('trainingBlockDays', trainingBlockDayReducer),
        EffectsModule.forFeature([TrainingProgramEffects]),
        FormsModule
    ],
    declarations: [
        TrainingProgramHomeComponent,

        TrainingProgramListComponent,
        TrainingProgramDetailsComponent,
        TrainingProgramCreateEditComponent,

        TrainingBlockDetailsComponent,
        TrainingBlockListComponent,
        TrainingBlockCreateEditComponent,

        TrainingBlockDayListComponent,
        TrainingBlockDayCreateEditComponent,

        BlockTrainingListComponent,
        BlockTrainingCreateEditComponent,
        BlockTrainingDetailsComponent,

        BlockExerciseListComponent,
        BlockExerciseCreateEditComponent,

        BlockSetsListComponent,
        BlockSetsCreateEditComponent,
    ],
    exports: [
    ],
    providers: [
        TrainingProgramService,
        TrainingProgramsResolver,

        TrainingBlockService,
        TrainingBlockDayService,

        UIService
    ],
    entryComponents: [
    ]
})
export class TrainingProgramModule { }
