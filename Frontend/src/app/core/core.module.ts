import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { NgChatModule } from 'ng-chat';
import { AvatarModule } from 'ngx-avatar';
import { CookieService } from 'ngx-cookie-service';
import { NgxStripeModule } from 'ngx-stripe';
import { ErrorInterceptor } from 'src/business/interceptors/error.interceptor';
import { HttpInterceptor } from 'src/business/interceptors/http.interceptor';
import { APP_SETTINGS_PROVIDER } from 'src/business/services/shared/app-settings.service';
import { environment } from 'src/environments/environment';
import { MaterialModule } from '../shared/angular-material.module';
import { ConfirmDialogComponent } from '../shared/confirm-dialog/confirm-dialog.component';
import { ErrorSnackbarComponent } from '../shared/error-snackbar/error-snackbar.component';
import { SanitizeHtmlPipe } from './../../business/pipes/sanitize-html.pipe';
import { MessageDialogComponent } from './../shared/message-dialog/message-dialog.component';
import { AppContainerComponent } from './app-container/app-container.component';
import { LoginComponent } from './authorization/login/login.component';
import { RegisterComponent } from './authorization/register/register.component';
import { CoreRoutingModule } from './core-routing.module';
import { SidebarComponent } from './navigation/sidebar/sidebar.component';
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
        CommonModule,
        BrowserAnimationsModule,
        CoreRoutingModule,
        HttpClientModule,
        ReactiveFormsModule,
        MaterialModule,
        AvatarModule,
        NgxStripeModule.forRoot(environment.stripePublishableKey),
        NgChatModule,
    ],
    declarations: [
        LoginComponent,
        RegisterComponent,

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
        
        ErrorSnackbarComponent,
        MessageDialogComponent,
        ConfirmDialogComponent,
        
        SanitizeHtmlPipe
    ],
    exports: [
        AvatarModule,
        CommonModule,
        ReactiveFormsModule,
        MaterialModule,
        RouterModule,
    ],
    providers: [
        CookieService,
        APP_SETTINGS_PROVIDER,
        { provide: HTTP_INTERCEPTORS, useClass: HttpInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
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
