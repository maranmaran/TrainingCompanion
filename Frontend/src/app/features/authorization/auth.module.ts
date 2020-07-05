import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { SetPasswordComponent } from './set-password/set-password.component';
import { RegisterExternalComponent } from './register-external/register-external.component';


@NgModule({
    imports: [
        AuthRoutingModule,
        SharedModule,
    ],
    declarations: [
        LoginComponent,
        RegisterComponent,
        ResetPasswordComponent,
        SetPasswordComponent,
        RegisterExternalComponent
    ],
    exports: [
    ],
    providers: [
    ],
    entryComponents: [
    ]
})
export class AuthModule { }
