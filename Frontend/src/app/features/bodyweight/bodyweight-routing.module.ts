import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BodyweightsResolver } from './../../../business/resolvers/bodyweights.resolver';
import { BodyweightHomeComponent } from './bodyweight-home/bodyweight-home.component';

const routes: Routes = [
    { path: '', component: BodyweightHomeComponent, resolve: { BodyweightsResolver }, children: [
    ]},
    { path: '**', redirectTo: '/' }, //always last
];

@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule
    ],
    providers: [

    ]
})
export class BodyweightRoutingModule {
}
