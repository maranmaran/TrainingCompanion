import { AbstractControl } from '@angular/forms';
import * as moment from 'moment';


export class DateValidators {

    static MatchHistoryDate(AC: AbstractControl) {

        const nowUtc = moment(new Date()).startOf('day');
        const selectedUtc = moment(AC.get('startDate').value).utc().startOf('day');

        if (selectedUtc.isSameOrAfter(nowUtc)) {
            return null;
        }

        AC.get('startDate').setErrors({ MatchHistoryDate: true });
    }
}
