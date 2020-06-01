import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotImplementedComponent } from 'src/app/shared/custom-preview-components/not-implemented/not-implemented.component';
import { ExercisePersonalBestResolver } from 'src/business/resolvers/exercise-personal-best.resolver';
import { TrainingDetailsResolver } from 'src/business/resolvers/training-details.resolver';
import { ExerciseDetailsComponent } from './exercise/exercise-details/exercise-details.component';
import { TrainingLogHomeComponent } from './training-log-home/training-log-home.component';
import { TrainingDetailsComponent } from './training/training-details/training-details.component';
import { TrainingListComponent } from './training/training-list/training-list.component';
import { TrainingMonthComponent } from './training/training-month/training-month.component';

const routes: Routes = [
    {
        path: '', component: TrainingLogHomeComponent, children: [
            { path: '', redirectTo: 'calendar/month' },
            { path: 'calendar/month', component: TrainingMonthComponent },
            { path: 'calendar/week', component: NotImplementedComponent },
            { path: 'list', component: TrainingListComponent },
            { path: 'training-details', resolve: { TrainingDetailsResolver }, component: TrainingDetailsComponent },
            { path: 'exercise-details', resolve: { TrainingDetailsResolver, ExercisePersonalBestResolver }, component: ExerciseDetailsComponent }
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
export class TrainingLogRoutingModule {
}
