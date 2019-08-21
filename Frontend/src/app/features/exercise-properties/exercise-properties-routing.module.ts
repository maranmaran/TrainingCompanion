import { ExercisePropertiesHomeComponent } from './exercise-properties-home/exercise-properties-home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExercisePropertyTypesResolver } from './../../../business/resolvers/exercise-property-types.resolver';

const routes: Routes = [
    { path: '', component: ExercisePropertiesHomeComponent, resolve: {ExercisePropertyTypesResolver}, children: [
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
export class ExercisePropertiesRoutingModule {
}
