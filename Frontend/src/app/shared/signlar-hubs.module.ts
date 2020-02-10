import { SignalrNgChatAdapter } from "../core/ng-chat/signalr-ng-chat-adapter"
import { NotificationSignalrService } from 'src/business/services/feature-services/notification-signalr.service'
import { ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core'

/**
 * Singleton services - this pattern is used to have singleton instances of services inside lazy loaded modules
 */
@NgModule({})
export class SignalrHubsModule {

    static forRoot(): ModuleWithProviders<SignalrHubsModule> {
        return {
            ngModule: SignalrHubsModule,
            providers: [
                SignalrNgChatAdapter,
                NotificationSignalrService 
            ]
        }
    }
    
}

