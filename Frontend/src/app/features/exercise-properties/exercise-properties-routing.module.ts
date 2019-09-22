import { ExercisePropertiesHomeComponent } from './exercise-properties-home/exercise-properties-home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TagGroupsResolver } from './../../../business/resolvers/tag-groups.resolver';

const routes: Routes = [
    {
        path: '', component: ExercisePropertiesHomeComponent, resolve: { TagGroupsResolver }, children: [
        ]
    },
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
