import { ExportJob } from 'src/app/features/export-import/models/export-job.model';
import { ImportJob } from 'src/app/features/export-import/models/import-job.model';
import { ImportResponse } from 'src/server-models/cqrs/import/import.response';
import { ExportResponse } from './../../server-models/cqrs/export/export.response';

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


