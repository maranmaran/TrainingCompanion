import { DashboardRoutingModule } from './dashboard-routing.module';
import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardHomeComponent } from './dashboard-home/dashboard-home.component';


@NgModule({
    imports: [
        SharedModule,
        DashboardRoutingModule,
    ],
    declarations: [
        DashboardHomeComponent,
    ],
    exports: [
    ],
    providers: [
    ],
    entryComponents: [
    ]
})
export class DashboardModule { }
