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

const routes: Routes = [
    { path: '', redirectTo: 'app', pathMatch: 'full' },
    { path: 'auth', loadChildren: () => import('src/app/features/authorization/auth.module').then(mod => mod.AuthModule) },
    {
        path: 'app', component: AppContainerComponent, canActivate: [AuthGuard], canActivateChild: [SubscriptionGuard], children: [
            { path: 'app', redirectTo: 'dashboard', pathMatch: 'full' },
            { path: 'dashboard', loadChildren: () => import('src/app/features/dashboard/dashboard.module').then(mod => mod.DashboardModule)},
            { path: 'media', loadChildren: () => import('src/app/features/media/media.module').then(mod => mod.MediaModule)},
            { path: 'athletes', loadChildren: () => import('src/app/features/athlete-management/athletes.module').then(mod => mod.AthletesModule), canActivate: [IsCoach]},
            {
                path: 'settings',  canActivate: [AuthGuard], children: [
                    { path: 'general', component: GeneralComponent },
                    { path: 'account', component: AccountComponent },
                    { path: 'billing', component: BillingComponent },
                ],
            },
        ]
    },
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


