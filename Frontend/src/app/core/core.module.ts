import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { EffectsModule } from '@ngrx/effects';
import { RouterState, StoreRouterConnectingModule } from '@ngrx/router-store';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { AvatarModule } from 'ngx-avatar';
import { CookieService } from 'ngx-cookie-service';
import { NgxStripeModule } from 'ngx-stripe';
import { CurrentUserLoadedGuard } from 'src/business/guards/current-user-loaded.guard';
import { ErrorInterceptor } from 'src/business/interceptors/error.interceptor';
import { HttpInterceptor } from 'src/business/interceptors/http.interceptor';
import { ChatService } from 'src/business/services/chat.service';
import { PushNotificationsService } from 'src/business/services/push-notification.service';
import { APP_SETTINGS_PROVIDER } from 'src/business/services/shared/app-settings.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { environment } from 'src/environments/environment';
import { CustomSerializer } from 'src/ngrx/custom.router-state-serializer';
import { metaReducers, reducers } from 'src/ngrx/global-setup.ngrx';
import { MaterialModule } from '../shared/angular-material.module';
import { ConfirmDialogComponent } from '../shared/confirm-dialog/confirm-dialog.component';
import { ErrorSnackbarComponent } from '../shared/error-snackbar/error-snackbar.component';
import { SharedModule } from '../shared/shared.module';
import { CoreEffects } from './../../ngrx/global-setup.ngrx';
import { MessageDialogComponent } from './../shared/message-dialog/message-dialog.component';
import { AppContainerComponent } from './app-container/app-container.component';
import { CoreRoutingModule } from './core-routing.module';
import { SidebarComponent } from './navigation/sidebar/sidebar.component';
import { ToolbarComponent } from './navigation/toolbar/toolbar.component';
import { NgChatModule } from './ng-chat/ng-chat.module';
import { SignalrNgChatAdapter } from './ng-chat/signalr-ng-chat-adapter';
import { AccountComponent } from './settings/account/account.component';
import { BillingComponent } from './settings/billing/billing.component';
import { CurrentSubscriptionComponent } from './settings/billing/current-subscription/current-subscription.component';
import { PlanComponent } from './settings/billing/plans/plan/plan.component';
import { PlansComponent } from './settings/billing/plans/plans.component';
import { StripeCheckoutComponent } from './settings/billing/stripe-checkout/stripe-checkout.component';
import { GeneralComponent } from './settings/general/general.component';
import { SettingsComponent } from './settings/settings.component';


@NgModule({
    imports: [
        SharedModule,
        CommonModule,
        BrowserAnimationsModule,
        CoreRoutingModule,
        HttpClientModule,
        ReactiveFormsModule,
        MaterialModule,
        AvatarModule,
        NgxStripeModule.forRoot(environment.stripePublishableKey),
        NgChatModule,
        StoreModule.forRoot(reducers, {
            metaReducers,
            runtimeChecks: {
                strictStateImmutability: true,
                strictActionImmutability: true,
            }
        }),
        StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: environment.production }),
        EffectsModule.forRoot(CoreEffects),
        StoreRouterConnectingModule.forRoot({
            stateKey: 'router',
            routerState: RouterState.Minimal,
            serializer: CustomSerializer
        })
    ],
    declarations: [
        AppContainerComponent,
        SidebarComponent,
        ToolbarComponent,
        SettingsComponent,
        BillingComponent,
        PlansComponent,
        PlanComponent,
        CurrentSubscriptionComponent,
        StripeCheckoutComponent,
        AccountComponent,
        GeneralComponent,
    ],
    exports: [
        AvatarModule,
        CommonModule,
        ReactiveFormsModule,
        MaterialModule,
        RouterModule,
    ],
    providers: [
        CurrentUserLoadedGuard,
        UIService,
        ChatService, // signalr connections must be singleton in this case
        PushNotificationsService,
        SignalrNgChatAdapter,
        CookieService,
        APP_SETTINGS_PROVIDER,
        { provide: HTTP_INTERCEPTORS, useClass: HttpInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        // { provide: APP_INITIALIZER, useFactory: initApplication, multi: true, deps: [Store, Actions] }
    ],
    entryComponents: [
        ErrorSnackbarComponent,
        SettingsComponent,
        StripeCheckoutComponent,
        ConfirmDialogComponent,
        MessageDialogComponent
    ]
})
export class CoreModule { }

