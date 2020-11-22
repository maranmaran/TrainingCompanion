import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExerciseDetailsResolver } from 'src/business/resolvers/exercise-details.resolver';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { ExerciseService } from 'src/business/services/feature-services/exercise.service';
import { ExerciseEffects } from 'src/ngrx/exercise/exercise.effects';
import { exerciseReducer } from 'src/ngrx/exercise/exercise.reducers';
import { SetModule } from '../set/set.module';
import { ExerciseCreateEditComponent } from './exercise-create-edit/exercise-create-edit.component';
import { ExerciseDetailsComponent } from './exercise-details/exercise-details.component';
import { ExerciseListComponent } from './exercise-list/exercise-list.component';

@NgModule({
  imports: [
      SharedModule,
      SetModule,
  ],
  declarations: [
      ExerciseListComponent,
      ExerciseCreateEditComponent,
      ExerciseDetailsComponent,
  ],
  exports: [
      ExerciseListComponent
  ],
  providers: [
      ExerciseService,
      ExerciseTypeService,
      ExerciseDetailsResolver,
  ],
  entryComponents: [
  ]
})
export class ExerciseModule {}
