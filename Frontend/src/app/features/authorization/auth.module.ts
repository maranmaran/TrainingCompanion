import { HttpBackend } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthorizationHttpLoaderFactory } from 'src/assets/i18n/translation-http-loader.factory';
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { SetPasswordComponent } from './set-password/set-password.component';


@NgModule({
    imports: [
        AuthRoutingModule,
        SharedModule,
        // lazy loaded modules import of translate module
        // https://github.com/ngx-translate/core#1-import-the-translatemodule
        TranslateModule.forChild({
          isolate: true,
          loader: {
            provide: TranslateLoader,
            useFactory: AuthorizationHttpLoaderFactory,
            deps: [HttpBackend]
          }
        })
    ],
    declarations: [
        LoginComponent,
        RegisterComponent,
        ResetPasswordComponent,
        SetPasswordComponent
    ],
    exports: [
    ],
    providers: [
    ],
    entryComponents: [
    ]
})
export class AuthModule { }
