import { TrainingDetailsResolver } from './../../../business/resolvers/training-details.resolver';
import { ExerciseDetailsResolver } from './../../../business/resolvers/exercise-details.resolver';
import { ExerciseDetailsComponent } from './exercise/exercise-details/exercise-details.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrainingLogHomeComponent } from './training-log-home/training-log-home.component';
import { TrainingCalendarComponent } from './training/training-calendar/training-calendar.component';
import { TrainingDetailsComponent } from './training/training-details/training-details.component';

const routes: Routes = [
    { path: '',  component: TrainingLogHomeComponent, children: [
        { path: '', redirectTo: 'calendar' },
        { path: 'calendar', component: TrainingCalendarComponent },
        { path: 'week', component: TrainingCalendarComponent },
        { path: 'list', component: TrainingCalendarComponent },
        { path: 'training-details', resolve: {TrainingDetailsResolver}, component: TrainingDetailsComponent },
        { path: 'exercise-details', resolve: {ExerciseDetailsResolver}, component: ExerciseDetailsComponent }
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
