import { TrainingProgramHomeComponent } from './training-program-home/training-program-home.component';
import { NgModule } from '@angular/core'; import { SharedModule } from 'src/app/shared/shared.module'; import { TrainingProgramRoutingModule } from './training-program-routing.module'; import { StoreModule } from '@ngrx/store'; import { trainingProgramReducer } from 'src/ngrx/training-program/training-program.reducers'; import { EffectsModule } from '@ngrx/effects'; import { TrainingProgramEffects } from 'src/ngrx/training-program/training-program.effects'; import { FormsModule } from '@angular/forms'; import { UIService } from 'src/business/services/shared/ui.service';
import { TrainingProgramsResolver } from 'src/business/resolvers/training-program.resolver';
import { TrainingProgramService } from 'src/business/services/feature-services/training-program.service';
import { TrainingProgramListComponent } from './training-program-home/training-program-list/training-program-list.component';
import { TrainingProgramDetailsComponent } from './training-program-home/training-program-details/training-program-details.component';
import { TrainingProgramCreateEditComponent } from './training-program-home/training-program-create-edit/training-program-create-edit.component';
import { TrainingBlockListComponent } from './training-program-home/training-block-list/training-block-list.component';
import { TrainingBlockCreateEditComponent } from './training-program-home/training-block-create-edit/training-block-create-edit.component';

@NgModule({
    imports: [
        SharedModule,
        TrainingProgramRoutingModule,
        StoreModule.forFeature('trainingPrograms', trainingProgramReducer),
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
