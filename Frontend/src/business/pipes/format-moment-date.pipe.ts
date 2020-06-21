import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment-timezone';

@Pipe({
  name: 'formatMomentDate'
})
export class FormatMomentDatePipe implements PipeTransform {
  // tslint:disable-next-line: ban-types
  transform(value: Object, format: string) {
    return (value as moment.Moment).format(format);
  }
}
