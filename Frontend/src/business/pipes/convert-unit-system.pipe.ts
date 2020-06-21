import { Pipe, PipeTransform } from '@angular/core';
import { UnitSystem, UnitSystemUnitOfMeasurement } from './../../server-models/enums/unit-system.enum';

@Pipe({
  name: 'showUnitSystemLabel'
})
export class ShowUnitSystemLabelPipe implements PipeTransform {

  // tslint:disable-next-line: ban-types
  transform(value: Object) {

    const system = value as UnitSystem;

    if(!system) {
      return '';
    }

    return system === UnitSystem.Metric ? UnitSystemUnitOfMeasurement.Metric : UnitSystemUnitOfMeasurement.Imperial;
  }
}
