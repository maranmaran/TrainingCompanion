import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Training } from 'src/server-models/entities/training.model';
import { CrudService } from '../crud.service';

export class TrainingService extends CrudService<Training> {

    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, "Training");
    }

    public getAllByMonth(userId: string, month: number, year: number) {
        return this.http.get<Training[]>(this.url + 'GetAllByMonth/' + userId + '/' + month + '/' + year)
            .pipe(
                catchError(this.handleError)
            );
    }

    public getAllByWeek(userId: string, weekStart: Date, weekEnd: Date) {
        return this.http.get<Training[]>(this.url + 'GetAll/' + userId + '/' + weekStart + '/' + weekEnd)
            .pipe(
                catchError(this.handleError)
            );
    }
}