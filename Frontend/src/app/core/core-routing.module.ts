import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/business/guards/auth.guard';
import { CurrentUserLoadedGuard } from 'src/business/guards/current-user-loaded.guard';
import { IsCoach } from 'src/business/guards/is-coach.guard';
import { SubscriptionGuard } from 'src/business/guards/subscription.guard';
import { AppContainerComponent } from './app-container/app-container.component';
import { BillingComponent } from './settings/billing/billing.component';

const routes: Routes = [
    { path: '', redirectTo: 'app', pathMatch: 'full' },
    { path: 'auth', loadChildren: () => import('src/app/features/authorization/auth.module').then(mod => mod.AuthModule) },
    { path: 'app', canActivate: [CurrentUserLoadedGuard], children: [
        {
            path: '', component: AppContainerComponent, canActivate: [AuthGuard, SubscriptionGuard],  children: [
                { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
                { path: 'dashboard', loadChildren: () => import('src/app/features/dashboard/dashboard.module').then(mod => mod.DashboardModule)},
                { path: 'athletes', loadChildren: () => import('src/app/features/athlete-management/athletes.module').then(mod => mod.AthletesModule), canActivate: [IsCoach]},
                { path: 'training-log', loadChildren: () => import('src/app/features/training-log/training-log.module').then(mod => mod.TrainingLogModule)},
                { path: 'exercise-properties', loadChildren: () => import('src/app/features/exercise-properties/exercise-properties.module').then(mod => mod.ExercisePropertiesModule)},
                { path: 'exercise-types', loadChildren: () => import('src/app/features/exercise-types/exercise-types.module').then(mod => mod.ExerciseTypesModule)},
                { path: 'export-import', loadChildren: () => import('src/app/features/export-import/export-import.module').then(mod => mod.ExportImportModule)},
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


