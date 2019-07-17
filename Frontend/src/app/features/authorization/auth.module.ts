import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { StoreModule } from '@ngrx/store';
import { authReducer } from 'src/ngrx/auth/auth.reducers';
import { EffectsModule } from '@ngrx/effects';
import { AuthEffects } from 'src/ngrx/auth/auth.effects';


@NgModule({
    imports: [
        AuthRoutingModule,
        SharedModule,
        StoreModule.forFeature('auth', authReducer),
        EffectsModule.forFeature([AuthEffects])
    ],
    declarations: [
        LoginComponent,
        RegisterComponent
    ],
    exports: [
    ],
    providers: [
    ],
    entryComponents: [
    ]
})
export class AuthModule { }
