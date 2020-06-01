import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { Pipe, PipeTransform } from '@angular/core';
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


@Pipe({
  name: 'transformRpe'
})
export class TransformRpePipe implements PipeTransform {

  constructor() {
  }

  // tslint:disable-next-line: ban-types
  transform(value: Object, system: RpeSystem) {
    return system == RpeSystem.Rpe ? value : 10 - (value as number);
  }
}
