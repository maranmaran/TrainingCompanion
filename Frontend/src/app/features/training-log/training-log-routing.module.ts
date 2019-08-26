import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrainingLogHomeComponent } from './training-log-home/training-log-home.component';

const routes: Routes = [
    { path: '',  component: TrainingLogHomeComponent, children: [
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
export class TrainingLogRoutingModule {
}
