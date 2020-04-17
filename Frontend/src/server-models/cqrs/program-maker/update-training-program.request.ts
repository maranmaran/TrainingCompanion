import { StringMap } from '@angular/compiler/src/compiler_facade_interface';

export class UpdateTrainingProgramRequest {
    constructor(data: Partial<UpdateTrainingProgramRequest>) {
        Object.assign(this, data);
    }

    id: string;
    name: string;
    description: string;
    image: string;
}