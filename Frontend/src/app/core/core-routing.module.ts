import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/business/guards/auth.guard';
import { CurrentUserLoadedGuard } from 'src/business/guards/current-user-loaded.guard';
import { IsCoach } from 'src/business/guards/is-coach.guard';
import { SubscriptionGuard } from 'src/business/guards/subscription.guard';
import { ChatResolver } from './../../business/resolvers/chat.resolver';
import { AppContainerComponent } from './app-container/app-container.component';
import { BillingComponent } from './settings/billing/billing.component';

const routes: Routes = [
    { path: '', redirectTo: 'app', pathMatch: 'full' },
    { path: 'auth', loadChildren: () => import('src/app/features/authorization/auth.module').then(mod => mod.AuthModule) },
    {
        path: 'app', canActivate: [CurrentUserLoadedGuard], children: [
            {
                path: '', component: AppContainerComponent, canActivate: [AuthGuard, SubscriptionGuard], resolve: { ChatResolver }, children: [
                    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
                    { path: 'dashboard', loadChildren: () => import('src/app/features/dashboard/dashboard.module').then(mod => mod.DashboardModule) },
                    { path: 'athletes', loadChildren: () => import('src/app/features/athlete-management/athletes.module').then(mod => mod.AthletesModule), canActivate: [IsCoach] },
                    { path: 'training-log', loadChildren: () => import('src/app/features/training-log/training-log.module').then(mod => mod.TrainingLogModule) },
                    { path: 'exercise-properties', loadChildren: () => import('src/app/features/exercise-properties/exercise-properties.module').then(mod => mod.ExercisePropertiesModule) },
                    { path: 'exercise-types', loadChildren: () => import('src/app/features/exercise-types/exercise-types.module').then(mod => mod.ExerciseTypesModule) },
                    { path: 'export-import', loadChildren: () => import('src/app/features/export-import/export-import.module').then(mod => mod.ExportImportModule) },
                    { path: 'bodyweight', loadChildren: () => import('src/app/features/bodyweight/bodyweight.module').then(mod => mod.BodyweightModule) },
                    { path: 'personal-best', loadChildren: () => import('src/app/features/personal-best/personal-best.module').then(mod => mod.PersonalBestModule) },
                    { path: 'chat', loadChildren: () => import('src/app/features/chat/chat.module').then(mod => mod.ChatModule) },
                    { path: 'training-program', loadChildren: () => import('src/app/features/training-program/training-program.module').then(mod => mod.TrainingProgramModule) },
                ]
            },
            {
                path: 'settings', component: AppContainerComponent, canActivate: [AuthGuard, IsCoach], children: [
                    { path: 'billing', component: BillingComponent },
                ],
            },
        ]
    },
    { path: '**', redirectTo: '/' }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules, enableTracing: false })
    ],
    exports: [
        RouterModule
    ],
    providers: [
    ]
})
export class CoreRoutingModule {
}
