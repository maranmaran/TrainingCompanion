import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { TrainingEffects } from 'src/ngrx/training-log/training.effects';
import { trainingReducer } from 'src/ngrx/training-log/training.reducers';
import { ExerciseModule } from './exercise/exercise.module';
import { SetModule } from './set/set.module';
import { TrainingLogHomeComponent } from './training-log-home/training-log-home.component';
import { TrainingLogRoutingModule } from './training-log-routing.module';
import { TrainingModule } from './training/training.module';

@NgModule({
    imports: [
        SharedModule,
        TrainingModule,
        ExerciseModule,
        SetModule,
        TrainingLogRoutingModule,
        // StoreModule.forFeature('trainingLogState', trainingLogReducerMap),
        StoreModule.forFeature('training', trainingReducer),
        EffectsModule.forFeature([TrainingEffects]),
    ],
    declarations: [
        TrainingLogHomeComponent,
    ],
    exports: [
    ],
    providers: [
    ],
    entryComponents: [
    ]
})
export class TrainingLogModule {}
