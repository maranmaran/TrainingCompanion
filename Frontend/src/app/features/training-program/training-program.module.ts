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
import { TrainingBlockDayEffects } from './../../../ngrx/training-program/training-block-day/training-block-day.effects';
import { trainingBlockDayReducer } from './../../../ngrx/training-program/training-block-day/training-block-day.reducers';
import { TrainingBlockEffects } from './../../../ngrx/training-program/training-block/training-block.effects';
import { trainingBlockReducer } from './../../../ngrx/training-program/training-block/training-block.reducers';
import { TrainingModule } from './../training-log/training/training.module';
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
        EffectsModule.forFeature([TrainingProgramEffects, TrainingBlockEffects, TrainingBlockDayEffects]),
        FormsModule,
        TrainingModule,
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
