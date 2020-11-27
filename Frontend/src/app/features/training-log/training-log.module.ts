import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExerciseEffects } from 'src/ngrx/exercise/exercise.effects';
import { exerciseReducer } from 'src/ngrx/exercise/exercise.reducers';
import { TrainingEffects } from 'src/ngrx/training-log/training.effects';
import { trainingReducer } from 'src/ngrx/training-log/training.reducers';
import { MediaService } from './../../../business/services/feature-services/media.service';
import { ExerciseModule } from './exercise/exercise.module';
import { SetModule } from './set/set.module';
import { TrainingLogHomeComponent } from './training-log-home/training-log-home.component';
import { TrainingLogRoutingModule } from './training-log-routing.module';
import { TrainingModule } from './training/training.module';

@NgModule({
    imports: [
        SharedModule,
        TrainingLogRoutingModule,
        StoreModule.forFeature('training', trainingReducer),
        EffectsModule.forFeature([TrainingEffects]),
        StoreModule.forFeature('exercise', exerciseReducer),
        EffectsModule.forFeature([ExerciseEffects]),
        TrainingModule,
        ExerciseModule,
        SetModule,
    ],
    declarations: [
        TrainingLogHomeComponent,
    ],
    exports: [
    ],
    providers: [
        MediaService
    ],
    entryComponents: [
    ]
})
export class TrainingLogModule {}
