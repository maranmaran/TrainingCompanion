import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VelocityHomeComponent } from './velocity-home/velocity-home.component';

const routes: Routes = [
    {
        path: '', component: VelocityHomeComponent, children: [
        ]
    },
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
export class VelocityRoutingModule {
}
