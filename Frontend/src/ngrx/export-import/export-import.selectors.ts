import { createFeatureSelector } from '@ngrx/store';
import { ExportImportState } from './export-import.state';


export const selectExportImportState = createFeatureSelector<ExportImportState>("exportImport");

// export const exportImports = createSelector(
//     selectExportImportState,
//     fromExportImport.selectAll
// );

