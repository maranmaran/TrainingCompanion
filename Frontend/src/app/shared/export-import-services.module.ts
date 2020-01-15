import { ModuleWithProviders, NgModule } from '@angular/core';
import { ExportService } from 'src/business/services/feature-services/export.service';
import { ImportService } from 'src/business/services/feature-services/import.service';
import { SignalrHubsModule } from './signlar-hubs.module';
/**
 * Singleton services - this pattern is used to have singleton instances of services inside lazy loaded modules
 */
@NgModule({})
export class ExportImportServicesModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SignalrHubsModule,
            providers: [
                ExportService,
                ImportService
            ]
        };
    }
}
