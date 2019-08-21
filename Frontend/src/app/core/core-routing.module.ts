import { AppComponent } from './../app.component';
import { AccountComponent } from './settings/account/account.component';
import { BillingComponent } from './settings/billing/billing.component';
import { GeneralComponent } from './settings/general/general.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/business/guards/auth.guard';
import { AppContainerComponent } from './app-container/app-container.component';
import { SubscriptionGuard } from 'src/business/guards/subscription.guard';
import { IsCoach } from 'src/business/guards/is-coach.guard';
import { CurrentUserLoadedGuard } from 'src/business/guards/current-user-loaded.guard';

const routes: Routes = [
    { path: '', redirectTo: 'app', pathMatch: 'full' },
    { path: 'auth', loadChildren: () => import('src/app/features/authorization/auth.module').then(mod => mod.AuthModule) },
    { path: 'app', canActivate: [CurrentUserLoadedGuard], children: [
        {
            path: '', component: AppContainerComponent, canActivate: [AuthGuard, SubscriptionGuard],  children: [
                { path: 'app', redirectTo: 'dashboard', pathMatch: 'full' },
                { path: 'dashboard', loadChildren: () => import('src/app/features/dashboard/dashboard.module').then(mod => mod.DashboardModule)},
                { path: 'media', loadChildren: () => import('src/app/features/media/media.module').then(mod => mod.MediaModule)},
                { path: 'athletes', loadChildren: () => import('src/app/features/athlete-management/athletes.module').then(mod => mod.AthletesModule), canActivate: [IsCoach]},
                { path: 'training-log', loadChildren: () => import('src/app/features/training-log/training-log.module').then(mod => mod.TrainingLogModule)},
                { path: 'exercise-properties', loadChildren: () => import('src/app/features/exercise-properties/exercise-properties.module').then(mod => mod.ExercisePropertiesModule)},
            ]
        },
        {
            path: 'settings', component: AppContainerComponent, canActivate: [AuthGuard], children: [
                { path: 'billing', component: BillingComponent },
            ],
        },
    ]},
    { path: '**', redirectTo: '/' }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ],
    providers: [
    ]
})
export class CoreRoutingModule {
}


