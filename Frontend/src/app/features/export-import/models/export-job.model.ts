import { ImportEntities } from 'src/server-models/enums/import-entities.enum';
import { JobBase } from './job-base.model';
import { ExportRequest } from 'src/server-models/cqrs/export/request/export.request';
import { ExportResponse } from 'src/server-models/cqrs/export/response/export.response';
import { ExportEntities } from 'src/server-models/enums/export-entities.enum';

export class ExportJob extends JobBase<ExportEntities>{
    constructor(type: ExportEntities) {
        super(type);
    }
}
