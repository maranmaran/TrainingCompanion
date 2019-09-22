import { CreateTagGroupRequest } from 'src/server-models/cqrs/tag-group/requests/create-tag-group.request';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../base.service';
import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { catchError } from 'rxjs/operators';
import { UpdateTagGroupRequest } from 'src/server-models/cqrs/tag-group/requests/update-tag-group.request';
import { CrudService } from '../crud.service';

export class TagGroupService extends CrudService<TagGroup> {

    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, "TagGroup");
    }

}