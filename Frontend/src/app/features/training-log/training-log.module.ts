import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { UIService } from 'src/business/services/shared/ui.service';
import { TrainingLogRoutingModule } from './training-log-routing.module';
import { TrainingLogHomeComponent } from './training-log-home/training-log-home.component';


@NgModule({
    imports: [
        SharedModule,
        TrainingLogRoutingModule,
        // StoreModule.forFeature('trainings', trainingsReducer),
        // EffectsModule.forFeature([TrainingEffects])
    ],
    declarations: [
        TrainingLogHomeComponent,
    ],
    exports: [
    ],
    providers: [
        UIService,
    ],
    entryComponents: [
    ]
})
export class TrainingLogModule { }
