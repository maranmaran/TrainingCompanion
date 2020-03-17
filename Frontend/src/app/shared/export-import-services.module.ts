import { ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core';
import { ExportService } from 'src/business/services/feature-services/export.service';
import { ImportService } from 'src/business/services/feature-services/import.service';
import { SignalrHubsModule } from './signalr-hubs.module';
/**
 * Singleton services - this pattern is used to have singleton instances of services inside lazy loaded modules
 */
@NgModule({})
export class ExportImportServicesModule {

    constructor (@Optional() @SkipSelf() parentModule?: ExportImportServicesModule) {
        if (parentModule) {
            throw new Error(
            'ExportImportServicesModule is already loaded. Import it in the CoreModule only');
        }
    }

    static forRoot(): ModuleWithProviders<ExportImportServicesModule> {
        return {
            ngModule: SignalrHubsModule,
            providers: [
                ExportService,
                ImportService
            ]
        };
    }
}
