import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from 'src/app/shared/shared.module';
import { ImportSampleDirective } from 'src/business/directives/import-sample.directive';
import { ExportService } from 'src/business/services/feature-services/export.service';
import { ImportService } from 'src/business/services/feature-services/import.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { ExportImportEffects } from 'src/ngrx/export-import/export-import.effects';
import { ExportImportResolver } from './../../../business/resolvers/export-import.resolver';
import { exportImportReducers } from './../../../ngrx/export-import/export-import.reducers';
import { ExportImportHomeComponent } from './export-import-home/export-import-home.component';
import { ExerciseTypeExportComponent } from './export-import-home/export/exercise-type-export/exercise-type-export.component';
import { ExportComponent } from './export-import-home/export/export.component';
import { TrainingExportComponent } from './export-import-home/export/training-export/training-export.component';
import { ExerciseTypeImportComponent } from './export-import-home/import/exercise-type-import/exercise-type-import.component';
import { ImportButtonComponent } from './export-import-home/import/import-button/import-button.component';
import { ImportComponent } from './export-import-home/import/import.component';
import { TrainingImportComponent } from './export-import-home/import/training-import/training-import.component';
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
        ExportComponent,
        ImportComponent,
        ExerciseTypeImportComponent,
        TrainingImportComponent,
        TrainingExportComponent,
        ExerciseTypeExportComponent,
        ImportButtonComponent,
        ImportSampleDirective
    ],
    exports: [
    ],
    providers: [
        UIService,
        ExportService,
        ImportService,
        ExportImportResolver
    ],
    entryComponents: [
    ]
})
export class ExportImportModule { }
