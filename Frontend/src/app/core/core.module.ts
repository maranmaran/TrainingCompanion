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
import { CookieService } from 'ngx-cookie-service';
import { NgxStripeModule } from 'ngx-stripe';
import { ToastrModule } from 'ngx-toastr';
import { CurrentUserLoadedGuard } from 'src/business/guards/current-user-loaded.guard';
import { ErrorInterceptor } from 'src/business/interceptors/error.interceptor';
import { HttpInterceptor } from 'src/business/interceptors/http.interceptor';
import { APP_SETTINGS_PROVIDER } from 'src/business/services/shared/app-settings.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { environment } from 'src/environments/environment';
import { CustomSerializer } from 'src/ngrx/custom.router-state-serializer';
import { metaReducers, reducers } from 'src/ngrx/global-setup.ngrx';
import { MaterialModule } from '../shared/angular-material.module';
import { ConfirmDialogComponent } from '../shared/dialogs/confirm-dialog/confirm-dialog.component';
import { ErrorSnackbarComponent } from '../shared/dialogs/error-snackbar/error-snackbar.component';
import { MessageDialogComponent } from '../shared/dialogs/message-dialog/message-dialog.component';
import { ExportImportServicesModule } from '../shared/export-import-services.module';
import { NotificationToastComponent } from '../shared/notifications/notification-toast/notification-toast.component';
import { SharedModule } from '../shared/shared.module';
import { SignalrHubsModule } from '../shared/signalr-hubs.module';
import { ChatResolver } from './../../business/resolvers/chat.resolver';
import { CoreEffects } from './../../ngrx/global-setup.ngrx';
import { ChatModule } from './../features/chat/chat.module';
import { AppContainerComponent } from './app-container/app-container.component';
import { CoreRoutingModule } from './core-routing.module';
import { SidebarComponent } from './navigation/sidebar/sidebar.component';
import { TabsComponent } from './navigation/tabs/tabs.component';
import { ToolbarComponent } from './navigation/toolbar/toolbar.component';
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
        NgxStripeModule.forRoot(environment.stripePublishableKey),
        ChatModule,
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
        }),
        ToastrModule.forRoot({
          timeOut: 2000,
          disableTimeOut : false,
          positionClass: 'toast-bottom-right',
          preventDuplicates: false,
          toastComponent: NotificationToastComponent // added custom toast!
        }), // ToastrModule added,
        SignalrHubsModule.forRoot(),
        ExportImportServicesModule.forRoot()
    ],
    declarations: [
        AppContainerComponent,
        SidebarComponent,
        ToolbarComponent,
        TabsComponent,
        SettingsComponent,
        BillingComponent,
        PlansComponent,
        PlanComponent,
        CurrentSubscriptionComponent,
        StripeCheckoutComponent,
        AccountComponent,
        GeneralComponent,
        NotificationToastComponent
    ],
    exports: [
        CommonModule,
        ReactiveFormsModule,
        MaterialModule,
        RouterModule,
    ],
    providers: [
        ChatResolver,
        CurrentUserLoadedGuard,
        UIService,
        CookieService,
        APP_SETTINGS_PROVIDER,
        { provide: HTTP_INTERCEPTORS, useClass: HttpInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        // { provide: MAT_HAMMER_OPTIONS, useClass: CustomHammerJsConfig }
        // { provide: APP_INITIALIZER, useFactory: initApplication, multi: true, deps: [Store, Actions] }
    ],
    entryComponents: [
        ErrorSnackbarComponent,
        SettingsComponent,
        StripeCheckoutComponent,
        ConfirmDialogComponent,
        MessageDialogComponent,
        NotificationToastComponent
    ]
})
export class CoreModule { }
