import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'repeat' })
export class RepeatPipe implements PipeTransform {
    transform(value: number): any {
        const iter = <Iterable<any>>{};
        iter[Symbol.iterator] = function* () {
            let n = 0;
            while (n < value) {
                yield ++n;
            }
        };
        return iter;
    }
}