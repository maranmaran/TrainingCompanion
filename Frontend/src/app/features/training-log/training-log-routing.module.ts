import { ExerciseDetailsComponent } from './exercise/exercise-details/exercise-details.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrainingLogHomeComponent } from './training-log-home/training-log-home.component';
import { TrainingCalendarComponent } from './training/training-calendar/training-calendar.component';
import { TrainingDetailsComponent } from './training/training-details/training-details.component';

const routes: Routes = [
    { path: '',  component: TrainingLogHomeComponent, children: [
        { path: 'calendar', component: TrainingCalendarComponent },
        { path: 'week', component: TrainingCalendarComponent },
        { path: 'list', component: TrainingCalendarComponent },
        { path: 'training-detail', component: TrainingDetailsComponent, children: [
            { path: 'exercise-detail', component: ExerciseDetailsComponent }
        ] },
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
