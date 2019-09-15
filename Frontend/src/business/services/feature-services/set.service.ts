import { Set } from '../../../server-models/entities/set.model';
import { HttpClient } from '@angular/common/http';
import { CrudService } from '../crud.service';

export class SetService extends CrudService<Set> {

    constructor(private httpDI: HttpClient) {
        super(httpDI, "Set");
    }
    
}
