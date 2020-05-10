import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FeedResolver } from 'src/business/resolvers/feed.resolver';
import { ExerciseTypesResolver } from './../../../business/resolvers/exercise-types.resolver';
import { DashboardHomeComponent } from './dashboard-home/dashboard-home.component';
import { TracksResolver } from 'src/business/resolvers/dashboard-tracks.resolver';

const routes: Routes = [
    {
        path: '', component: DashboardHomeComponent, resolve: [TracksResolver, FeedResolver, ExerciseTypesResolver], children: [
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
export class DashboardRoutingModule {
}
