import { Plan } from './../../server-models/stripe/plan.model';
import { Injectable } from '@angular/core';
import { plainToClass } from "class-transformer";
import { Subscription } from 'src/server-models/stripe/subscription.model';
import { IBaseAdapter } from './base.adapter.interface';

@Injectable({
    providedIn: 'root'
})
export class PlanAdapter implements IBaseAdapter<Plan> {

// tslint:disable-next-line: ban-types
    adaptToModel(plainObject: Object): Plan {
        return plainToClass(Plan, plainObject, {
          excludeExtraneousValues: true
        });
    }

    adaptToList(plainObjectList: Object[]) {
        return plainToClass(Plan, plainObjectList, {
            excludeExtraneousValues: true
          });
    }

}
