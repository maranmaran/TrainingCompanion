import { CommonModule } from '@angular/common';
import { HttpBackend, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { forwardRef, NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { EffectsModule } from '@ngrx/effects';
import { RouterState, StoreRouterConnectingModule } from '@ngrx/router-store';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { TranslateLoader, TranslateModule, TranslateService } from '@ngx-translate/core';
import { FacebookLoginProvider, GoogleLoginProvider, SocialAuthServiceConfig, SocialLoginModule } from 'angularx-social-login';
import { CookieService } from 'ngx-cookie-service';
import { NgxStripeModule } from 'ngx-stripe';
import { ToastrModule } from 'ngx-toastr';
import { NotificationToastComponent } from 'src/app/shared/notifications/notification-toast/notification-toast.component';
import { PaginatorTranslateFactory } from 'src/assets/i18n/paginator-translate.factory';
import { HttpLoaderFactory } from 'src/assets/i18n/translation-http-loader.factory';
import { CurrentUserLoadedGuard } from 'src/business/guards/current-user-loaded.guard';
import { ErrorInterceptor } from 'src/business/interceptors/error.interceptor';
import { HttpInterceptor } from 'src/business/interceptors/http.interceptor';
import { APP_SETTINGS_PROVIDER, NOTIFICATION_TOAST_TOKEN } from 'src/business/services/shared/app-settings.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { environment } from 'src/environments/environment';
import { CustomSerializer } from 'src/ngrx/custom.router-state-serializer';
import { metaReducers, reducers } from 'src/ngrx/global-setup.ngrx';
import { MaterialModule } from '../shared/angular-material.module';
import { ExportImportServicesModule } from '../shared/export-import-services.module';
import { SharedModule } from '../shared/shared.module';
import { SignalrHubsModule } from '../shared/signalr-hubs.module';
import { ChatResolver } from './../../business/resolvers/chat.resolver';
import { CoreEffects } from './../../ngrx/global-setup.ngrx';
import { ChatModule } from './../features/chat/chat.module';
import { AppContainerComponent } from './app-container/app-container.component';
import { CoreRoutingModule } from './core-routing.module';
import { SidebarDesktopComponent } from './navigation/sidebar/sidebar-desktop.component';
import { SidebarMobileComponent } from './navigation/sidebar/sidebar-mobile.component';
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
import { ViewAsComponent } from './view-as/view-as.component';

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
        ToastrModule.forRoot(), // ToastrModule added,
        SignalrHubsModule.forRoot(),
        ExportImportServicesModule.forRoot(),
        TranslateModule.forRoot({
            isolate: false,
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [HttpBackend]
            }
        }),
        SocialLoginModule
    ],
    declarations: [
        AppContainerComponent,
        SidebarComponent,
        SidebarMobileComponent,
        SidebarDesktopComponent,
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
        NotificationToastComponent,
        ViewAsComponent,
        // PullToRefreshComponent
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
        {
            provide: MatPaginatorIntl, deps: [TranslateService],
            useFactory: (translateService: TranslateService) => new PaginatorTranslateFactory(translateService).getPaginatorIntl()
        },
        { provide: NOTIFICATION_TOAST_TOKEN, useFactory: forwardRef(() => NotificationToastComponent) },
        // { provide: MAT_HAMMER_OPTIONS, useClass: CustomHammerJsConfig }
        // { provide: APP_INITIALIZER, useFactory: initApplication, multi: true, deps: [Store, Actions] }
        {
            provide: 'SocialAuthServiceConfig',
            useValue: {
                autoLogin: false,
                providers: [
                    {
                        id: GoogleLoginProvider.PROVIDER_ID,
                        provider: new GoogleLoginProvider(
                            environment.googleClientID
                        ),
                    },
                    {
                        id: FacebookLoginProvider.PROVIDER_ID,
                        provider: new FacebookLoginProvider(
                            environment.facebookClientID
                        ),
                    },
                ],
            } as SocialAuthServiceConfig,
        }
    ],
    entryComponents: [
        // TODO remove after ~30 days - 09.07.20
        // ErrorSnackbarComponent,
        // SettingsComponent,
        // StripeCheckoutComponent,
        // ConfirmDialogComponent,
        // MessageDialogComponent,
        // NotificationToastComponent
    ]
})
export class CoreModule { }
