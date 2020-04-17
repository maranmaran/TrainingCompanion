import { TrainingProgramHomeComponent } from './training-program-home/training-program-home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrainingProgramsResolver } from 'src/business/resolvers/training-program.resolver';

const routes: Routes = [
    {
        path: '', component: TrainingProgramHomeComponent, resolve: { TrainingProgramsResolver }, children: [
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
export class TrainingProgramRoutingModule {
}
