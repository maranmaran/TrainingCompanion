import { ExportJob } from 'src/app/features/export-import/models/export-job.model';
import { ImportJob } from 'src/app/features/export-import/models/import-job.model';
import { ImportResponse } from 'src/server-models/cqrs/import/response/import.response';
import { ExportResponse } from './../../server-models/cqrs/export/response/export.response';

// Exercise property type ENTITY
export interface ExportImportState {
  importJobs: ImportJob[],
  exportJobs: ExportJob[]
  lastImportResponse: ImportResponse,
  lastExportResponse: ExportResponse
}

export const initExportImportState: ExportImportState = {
    exportJobs: [],
    importJobs: [],
    lastExportResponse: undefined,
    lastImportResponse: undefined
};


