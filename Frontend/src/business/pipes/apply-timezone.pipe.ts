import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment-timezone';

@Pipe({
  name: 'applyTimezone'
})
export class ApplyTimezonePipe implements PipeTransform {
  // tslint:disable-next-line: ban-types
  transform(value: Object) {
    return applyUserTimezone(value as Date).format('HH:mm');
  }
}

export function applyUserTimezone(date: Date) {
  const timezone = Intl.DateTimeFormat().resolvedOptions().timeZone;
  const utcTime = moment.utc(date);
  const withAppliedTz = utcTime.tz(timezone);
  return withAppliedTz;
}