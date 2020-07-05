import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterExternalComponent } from './register-external/register-external.component';
import { RegisterComponent } from './register/register.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { SetPasswordComponent } from './set-password/set-password.component';

const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'register-external', component: RegisterExternalComponent },
    { path: 'reset-password', component: ResetPasswordComponent },
    { path: 'set-password/:id', component: SetPasswordComponent },
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
export class AuthRoutingModule {
}
