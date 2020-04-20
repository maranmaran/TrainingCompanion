import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExerciseDetailsResolver } from 'src/business/resolvers/exercise-details.resolver';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { ExerciseService } from 'src/business/services/feature-services/exercise.service';
import { ExerciseCreateEditComponent } from './exercise-create-edit/exercise-create-edit.component';
import { ExerciseDetailsComponent } from './exercise-details/exercise-details.component';
import { ExerciseListComponent } from './exercise-list/exercise-list.component';

@NgModule({
  imports: [
      SharedModule,
  ],
  declarations: [
      ExerciseListComponent,
      ExerciseCreateEditComponent,
      ExerciseDetailsComponent,
  ],
  exports: [
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
