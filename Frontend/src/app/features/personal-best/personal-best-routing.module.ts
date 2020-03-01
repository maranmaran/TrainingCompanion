import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllExerciseTypesResolver } from './../../../business/resolvers/all-exercise-types.resolver';
import { PersonalBestsResolver } from './../../../business/resolvers/personal-bests.resolver';
import { PersonalBestHomeComponent } from './personal-best-home/personal-best-home.component';

const routes: Routes = [
    { path: '', component: PersonalBestHomeComponent, resolve: { PersonalBestsResolver, AllExerciseTypesResolver }, children: [
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
