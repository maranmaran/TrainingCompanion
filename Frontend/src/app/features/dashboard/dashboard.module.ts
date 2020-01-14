import { DashboardRoutingModule } from './dashboard-routing.module';
import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardHomeComponent } from './dashboard-home/dashboard-home.component';
import { DashboardCardContainerComponent } from './dashboard-card-container/dashboard-card-container.component';
import { TestCardComponent } from './dashboard-card-container/card-components/test-card/test-card.component';
import { DashboardOutletDirective } from './directives/dashboard-outlet.directive';


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
