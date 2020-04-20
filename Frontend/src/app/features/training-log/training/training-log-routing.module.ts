import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotImplementedComponent } from 'src/app/shared/custom-preview-components/not-implemented/not-implemented.component';
import { TrainingDetailsResolver } from '../../../../business/resolvers/training-details.resolver';
import { ExerciseDetailsComponent } from '../exercise/exercise-details/exercise-details.component';
import { TrainingLogHomeComponent } from '../training-log-home/training-log-home.component';
import { TrainingDetailsComponent } from './training-details/training-details.component';
import { TrainingMonthComponent } from './training-month/training-month.component';

const routes: Routes = [
    {
        path: '', component: TrainingLogHomeComponent, children: [
            { path: '', redirectTo: 'calendar/month' },
            { path: 'calendar/month', component: TrainingMonthComponent },
            { path: 'calendar/week', component: NotImplementedComponent },
            { path: 'list', component: NotImplementedComponent },
            { path: 'training-details', resolve: { TrainingDetailsResolver }, component: TrainingDetailsComponent },
            { path: 'exercise-details', resolve: { TrainingDetailsResolver }, component: ExerciseDetailsComponent }
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
