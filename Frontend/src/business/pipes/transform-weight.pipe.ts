import { Pipe, PipeTransform } from '@angular/core';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { transformWeight } from '../services/shared/unit-system.service';

@Pipe({
  name: 'transformWeight'
})
export class TransformWeightPipe implements PipeTransform {

  constructor() {
  }

  // tslint:disable-next-line: ban-types
  transform(value: Object, system: UnitSystem) {
    return transformWeight(value as number, system);
  }
}


