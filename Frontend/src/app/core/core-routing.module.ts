import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/business/guards/auth.guard';
import { AppContainerComponent } from './app-container/app-container.component';
import { SubscriptionGuard } from 'src/business/guards/subscription.guard';

const routes: Routes = [
    { path: 'auth', loadChildren: () => import('src/app/features/authorization/auth.module').then(mod => mod.AuthModule) },
    {
        path: '', component: AppContainerComponent, canActivate: [AuthGuard], canActivateChild: [SubscriptionGuard], children: [
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
            { path: 'dashboard', loadChildren: () => import('src/app/features/dashboard/dashboard.module').then(mod => mod.DashboardModule)},
            { path: 'media', loadChildren: () => import('src/app/features/media/media.module').then(mod => mod.MediaModule)},
        ]
    },
    {
        path: 'settings',  canActivate: [AuthGuard], children: [
            { path: 'general', data: { section: 'General' }, component: AppContainerComponent },
            { path: 'account', data: { section: 'Account' }, component: AppContainerComponent },
            { path: 'billing', data: { section: 'Billing' }, component: AppContainerComponent },
        ],
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


