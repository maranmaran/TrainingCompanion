import { HttpClient } from '@angular/common/http';
import { Tag } from 'src/server-models/entities/tag.model';
import { CrudService } from '../crud.service';
import { catchError } from 'rxjs/operators';

export class TagService extends CrudService<Tag> {

    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, "Tag");
    }

    public getAll(userId?: string, typeId?: string) {
        return this.http.get<Tag[]>(this.url + 'GetAll/' + userId + '/' + typeId)
            .pipe(
                catchError(this.handleError)
            );
    }
}