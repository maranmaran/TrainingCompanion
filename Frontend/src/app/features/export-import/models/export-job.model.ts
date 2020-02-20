import { ExportEntities } from 'src/server-models/enums/export-entities.enum';
import { JobBase } from './job-base.model';

export class ExportJob extends JobBase<ExportEntities>{
    constructor(type: ExportEntities) {
        super(type);
    }
}
