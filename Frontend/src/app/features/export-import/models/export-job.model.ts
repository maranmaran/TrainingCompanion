import { ImportEntities } from 'src/server-models/enums/import-entities.enum';
import { JobBase } from './job-base.model';

export class ExportJob extends JobBase<ImportEntities>{ }
