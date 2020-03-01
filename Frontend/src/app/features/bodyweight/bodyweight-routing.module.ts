import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BodyweightHomeComponent } from './bodyweight-home/bodyweight-home.component';

const routes: Routes = [
    { path: '', component: BodyweightHomeComponent, resolve: { }, children: [
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
