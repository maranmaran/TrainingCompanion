import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'splitPascalCase'
  })
  export class SplitPascalCasePipe implements PipeTransform {
    transform(value: string) {
      return value.replace(/([A-Z])/g, ' $1') // insert a space before all caps
                  .replace(/^./, function(str){ return str.toUpperCase(); }); // uppercase the first character
    }
  }
