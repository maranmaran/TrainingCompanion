import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { DeviceMotionService } from './services/device-motion.service';
import { VelocityRoutingModule } from './velocity.routing-module';

@NgModule({
    imports: [
        SharedModule,
        VelocityRoutingModule,
    ],
    declarations: [
    ],
    exports: [
    ],
    providers: [
      DeviceMotionService,
    ],
    entryComponents: [
    ]
})
export class VelocityModule { }
