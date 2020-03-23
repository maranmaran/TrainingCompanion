import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardHomeComponent } from './dashboard-home/dashboard-home.component';
import { FeedResolver } from 'src/business/resolvers/feed.resolver';

const routes: Routes = [
    { path: '', component: DashboardHomeComponent, resolve: [ FeedResolver ], children: [
    ]},
    { path: '**', redirectTo: '/' }, //always last
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ],
    providers: [
    ]
})
export class DashboardRoutingModule {
}
