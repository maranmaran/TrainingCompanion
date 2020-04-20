import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { SetService } from 'src/business/services/feature-services/set.service';
import { SetCreateEditComponent } from './set-create-edit/set-create-edit.component';
import { SetListComponent } from './set-list/set-list.component';

@NgModule({
  imports: [
      SharedModule,
  ],
  declarations: [
      SetListComponent,
      SetCreateEditComponent,
  ],
  exports: [
  ],
  providers: [
      SetService,
  ],
  entryComponents: [
  ]
})
export class SetModule {}
