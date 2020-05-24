import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExercisePersonalBestResolver } from 'src/business/resolvers/exercise-personal-best.resolver';
import { PersonalBestService } from 'src/business/services/feature-services/personal-best.service';
import { SetService } from 'src/business/services/feature-services/set.service';
import { ChooseMaxDialogComponent } from './set-create-edit/choose-max-dialog/choose-max-dialog.component';
import { SetCreateEditComponent } from './set-create-edit/set-create-edit.component';
import { SetListComponent } from './set-list/set-list.component';

@NgModule({
  imports: [
      SharedModule,
  ],
  declarations: [
      SetListComponent,
      SetCreateEditComponent,
      ChooseMaxDialogComponent,
  ],
  exports: [
      SetListComponent
  ],
  providers: [
      SetService,
      PersonalBestService,
      ExercisePersonalBestResolver
  ],
  entryComponents: [

  ]
})
export class SetModule {}
