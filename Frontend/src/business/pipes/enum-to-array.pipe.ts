import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'enumToArray'
  })
  export class EnumToArrayPipe implements PipeTransform {
    // tslint:disable-next-line: ban-types
    transform(value: Object) {
      return Object.keys(value).map(o => ({index: +o, name: value[o]}));
    }
  }
