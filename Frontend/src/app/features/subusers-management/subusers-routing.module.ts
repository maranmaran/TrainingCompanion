import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SubusersHomeComponent } from './subusers-home/subusers-home.component';
import { SubusersResolver } from 'src/business/resolvers/subusers.resolver';

const routes: Routes = [
    { path: '', component: SubusersHomeComponent, resolve: {SubusersResolver}, children: [
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
export class SubusersRoutingModule {
}
