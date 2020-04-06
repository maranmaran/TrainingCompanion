import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AthletesResolver } from 'src/business/resolvers/athletes.resolver';
import { AthletesHomeComponent } from './athletes-home/athletes-home.component';

const routes: Routes = [
    { path: '', component: AthletesHomeComponent, resolve: {AthletesResolver}, children: [
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
export class AthletesRoutingModule {
}
