import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment-timezone';

@Pipe({
  name: 'applyTimezone'
})
export class ApplyTimezonePipe implements PipeTransform {
  // tslint:disable-next-line: ban-types
  transform(value: Object) {

    const timezone = Intl.DateTimeFormat().resolvedOptions().timeZone;
    const utcTime = moment.utc(value);
    const withAppliedTz = utcTime.tz(timezone);

    return withAppliedTz.format('HH:mm');
  }
}
