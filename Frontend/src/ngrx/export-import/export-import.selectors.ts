import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ImportEntities } from 'src/server-models/enums/import-entities.enum';
import { ExportImportState } from './export-import.state';


export const selectExportImportState = createFeatureSelector<ExportImportState>("exportImport");

export const activeImportJobs = createSelector(
    selectExportImportState,
    state => (type: ImportEntities) => state.importJobs.filter(job => job.type == type && job.active)
);

export const activeExportJobs = createSelector(
  selectExportImportState,
  state => (type: ImportEntities) => state.importJobs.filter(job => job.type == type && job.active)
);

export const lastImportResponse = createSelector(
  selectExportImportState,
  state => state.lastImportResponse
)

export const lastExportResponse = createSelector(
  selectExportImportState,
  state => state.lastExportResponse
)

