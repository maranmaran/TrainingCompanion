import { DashboardRoutingModule } from './dashboard-routing.module';
import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardHomeComponent } from './dashboard-home/dashboard-home.component';
import { DashboardOutletDirective } from './directives/dashboard-outlet.directive';
import { DashboardCardContainerComponent } from './dashboard-home/dashboard-card-container/dashboard-card-container.component';
import { TestCardComponent } from './dashboard-home/dashboard-card-container/card-components/test-card/test-card.component';


@NgModule({
    imports: [
        SharedModule,
        DashboardRoutingModule,
    ],
    declarations: [
        DashboardHomeComponent,
        DashboardOutletDirective,
        DashboardCardContainerComponent,
        TestCardComponent,
    ],
    exports: [
    ],
    providers: [
    ],
    entryComponents: [
        TestCardComponent
    ]
})
export class DashboardModule { }
