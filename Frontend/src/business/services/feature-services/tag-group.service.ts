import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { TagGroup } from 'src/server-models/entities/tag-group.model';
import { CrudService } from '../crud.service';

@Injectable()
export class TagGroupService extends CrudService<TagGroup> {

    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, "TagGroup");
    }

}
