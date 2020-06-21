import { Pipe, PipeTransform } from '@angular/core';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';

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
