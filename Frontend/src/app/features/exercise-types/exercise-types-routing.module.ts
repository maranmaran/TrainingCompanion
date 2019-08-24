import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExerciseTypesHomeComponent } from './exercise-types-home/exercise-types-home.component';
import { ExerciseTypesResolver } from 'src/business/resolvers/exercise-types.resolver';

const routes: Routes = [
    { path: '', component: ExerciseTypesHomeComponent, resolve: {ExerciseTypesResolver}, children: [
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
export class ExerciseTypesRoutingModule {
}
