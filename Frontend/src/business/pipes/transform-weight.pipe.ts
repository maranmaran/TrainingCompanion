import { Pipe, PipeTransform } from '@angular/core';
import { transformWeight } from '../services/shared/unit-system.service';

@Pipe({
  name: 'transformWeight'
})
export class TransformWeightPipe implements PipeTransform {

  constructor() {
  }

  // tslint:disable-next-line: ban-types
  transform(value: Object, system: any) {
    return transformWeight(value as number, system);
  }
}
