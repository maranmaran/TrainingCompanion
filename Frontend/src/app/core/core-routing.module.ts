import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/business/guards/auth.guard';
import { CurrentUserResolver } from 'src/business/resolvers/current-user.resolver';
import { AppContainerComponent } from './app-container/app-container.component';

const routes: Routes = [
    { path: 'auth', loadChildren: () => import('src/app/features/authorization/auth.module').then(mod => mod.AuthModule) },    
    {
        path: '', resolve: { currentUser: CurrentUserResolver }, component: AppContainerComponent, canActivate: [AuthGuard], children: [
            { path: 'settings', component: AppContainerComponent, children: [
                    { path: 'general', data: { section: 'General' }, component: AppContainerComponent },
                    { path: 'account', data: { section: 'Account' }, component: AppContainerComponent },
                    { path: 'billing', data: { section: 'Billing' }, component: AppContainerComponent },
                ],
            },
            { path: 'media', loadChildren: () => import('src/app/features/media/media.module').then(mod => mod.MediaModule) },     
        ]
    },
    // {
    //     // path: 'chat', loadChildren: () => import('src/app/features/chat/chat.module').then(mod => mod.ChatModule)
    // },
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
