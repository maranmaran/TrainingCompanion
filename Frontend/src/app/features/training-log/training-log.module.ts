import { MediaService } from './../../../business/services/feature-services/media.service';
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
        TrainingLogRoutingModule,
        StoreModule.forFeature('training', trainingReducer),
        EffectsModule.forFeature([TrainingEffects]),
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
