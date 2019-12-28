import { HttpClient } from '@angular/common/http';
import { BaseService } from '../base.service';

export class ImportService extends BaseService {

    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, "Exercise");
    }


}

