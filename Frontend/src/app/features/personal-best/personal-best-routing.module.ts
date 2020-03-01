import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonalBestHomeComponent } from './personal-best-home/personal-best-home.component';

const routes: Routes = [
    { path: '', component: PersonalBestHomeComponent, resolve: { }, children: [
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
export class PersonalBestRoutingModule {
}
