import { createAction, props } from '@ngrx/store';
import { Guid } from 'guid-typescript';
import { ExportJob } from 'src/app/features/export-import/models/export-job.model';
import { ImportJob } from 'src/app/features/export-import/models/import-job.model';
import { ExportResponse } from 'src/server-models/cqrs/export/response/export.response';
import { ImportResponse } from 'src/server-models/cqrs/import/response/import.response';

export const addImportJob = createAction(
  '[Import] Set job',
  props<{ job: ImportJob }>()
);

export const addExportJob = createAction(
  '[Export] Set job',
  props<{ job: ExportJob }>()
);

export const updateImportJob = createAction(
  '[Import] Update job',
  props<{ id: Guid, job: ImportJob }>()
);

export const updateExportJob = createAction(
  '[Export] Update job',
  props<{ id: Guid, job: ExportJob }>()
);

export const setImportResponse = createAction(
  '[Import] Set response',
  props<{ response: ImportResponse }>()
);

export const setExportResponse = createAction(
  '[Export] Set response',
  props<{ response: ExportResponse }>()
);

export const removeImportJob = createAction(
  '[Import] Remove job',
  props<{ id: Guid }>()
);

export const removeExportJob = createAction(
  '[Export] Remove job',
  props<{ id: Guid }>()
);
