import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardHomeComponent } from './dashboard-home/dashboard-home.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardOutletDirective } from './directives/dashboard-outlet.directive';


@NgModule({
    imports: [
        SharedModule,
        DashboardRoutingModule,
    ],
    declarations: [
        DashboardHomeComponent,
        DashboardOutletDirective,
    ],
    exports: [
    ],
    providers: [
    ],
    entryComponents: [
    ]
})
export class DashboardModule { }
