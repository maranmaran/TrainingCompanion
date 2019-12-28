import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExportService } from 'src/business/services/feature-services/export.service';
import { ImportService } from 'src/business/services/feature-services/import.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ExportImportEffects } from 'src/ngrx/export-import/export-import.effects';
import { exportImportReducers } from './../../../ngrx/export-import/export-import.reducers';
import { ExportImportHomeComponent } from './export-import-home/export-import-home.component';
import { ExportImportRoutingModule } from './export-import-routing.module';

@NgModule({
    imports: [
        SharedModule,
        ExportImportRoutingModule,
        StoreModule.forFeature('exportImport', exportImportReducers),
        EffectsModule.forFeature([ExportImportEffects]),
    ],
    declarations: [
        ExportImportHomeComponent,
    ],
    exports: [
    ],
    providers: [
        UIService,
        ExportService,
        ImportService
    ],
    entryComponents: [
    ]
})
export class ExportImportModule { }
