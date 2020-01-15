import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { Guid } from 'guid-typescript';
import { ExportJob } from 'src/app/features/export-import/models/export-job.model';
import { ImportResponse } from 'src/server-models/cqrs/import/response/import.response';
import { ImportJob } from './../../app/features/export-import/models/import-job.model';
import { ExportResponse } from './../../server-models/cqrs/export/response/export.response';
import * as ExportImportActions from './export-import.actions';
import { ExportImportState, initExportImportState } from './export-import.state';

export const exportImportReducers: ActionReducer<ExportImportState, Action> = createReducer(
  initExportImportState,

  on(ExportImportActions.addImportJob, (state: ExportImportState, payload: { job: ImportJob }) => {
    return {
      ...state,
      importJobs: [...state.importJobs, payload.job]
    }
  }),

  on(ExportImportActions.addExportJob, (state: ExportImportState, payload: { job: ExportJob }) => {
    return {
      ...state,
      exportJobs: [...state.exportJobs, payload.job]
    }
  }),

  on(ExportImportActions.removeImportJob, (state: ExportImportState, payload: { id: Guid }) => {
    return {
      ...state,
      importJobs: state.importJobs.filter(job => job.id != payload.id)
    }
  }),

  on(ExportImportActions.removeExportJob, (state: ExportImportState, payload: { id: Guid }) => {
    return {
      ...state,
      exportJobs: state.exportJobs.filter(job => job.id != payload.id)
    }
  }),

  on(ExportImportActions.setImportResponse, (state: ExportImportState, payload: { response: ImportResponse }) => {
    return {
      ...state,
      lastImportResponse: payload.response
    }
  }),

  on(ExportImportActions.setExportResponse, (state: ExportImportState, payload: { response: ExportResponse }) => {
    return {
      ...state,
      lastExportResponse: payload.response
    }
  }),


)
