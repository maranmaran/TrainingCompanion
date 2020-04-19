import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { TrainingProgramsResolver } from 'src/business/resolvers/training-program.resolver';
import { TrainingProgramService } from 'src/business/services/feature-services/training-program.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { TrainingProgramEffects } from 'src/ngrx/training-program/training-program/training-program.effects';
import { trainingProgramReducer } from 'src/ngrx/training-program/training-program/training-program.reducers';
import { trainingBlockDayReducer } from './../../../ngrx/training-program/training-block-day/training-block-day.reducers';
import { trainingBlockReducer } from './../../../ngrx/training-program/training-block/training-block.reducers';
import { TrainingBlockCreateEditComponent } from './training-program-home/training-block-create-edit/training-block-create-edit.component';
import { TrainingBlockListComponent } from './training-program-home/training-block-list/training-block-list.component';
import { TrainingProgramCreateEditComponent } from './training-program-home/training-program-create-edit/training-program-create-edit.component';
import { TrainingProgramDetailsComponent } from './training-program-home/training-program-details/training-program-details.component';
import { TrainingProgramHomeComponent } from './training-program-home/training-program-home.component';
import { TrainingProgramListComponent } from './training-program-home/training-program-list/training-program-list.component';
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
        TrainingBlockListComponent,
        TrainingBlockCreateEditComponent,
        // TrainingProgramListComponent,
        // TrainingProgramCreateEditComponent,
        // TrainingProgramChartComponent,
    ],
    exports: [
    ],
    providers: [
        TrainingProgramService,
        TrainingProgramsResolver,
        UIService
    ],
    entryComponents: [
        // TrainingProgramCreateEditComponent
    ]
})
export class TrainingProgramModule { }
