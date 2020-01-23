import { ImportResponse } from 'src/server-models/cqrs/import/response/import.response';
import { ImportEntities } from 'src/server-models/enums/import-entities.enum';
import { JobBase } from './job-base.model';

export class ImportJob extends JobBase<ImportEntities>{
  
  constructor(type: ImportEntities) {
    super(type);
  }
}
