import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Store } from '@ngrx/store';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { take, map } from 'rxjs/operators';
import { unitSystem } from 'src/ngrx/auth/auth.selectors';
import { OnInit } from '@angular/core';

export class UnitSystemService {

    private MASS_KG_LBS = 2.2046;
    private unitSystem: UnitSystem;

    constructor(
        private store: Store<AppState>
    ) {
        this.store.select(unitSystem).pipe(take(1)).subscribe(system => this.unitSystem = system);
    }

    public transformWeight(weight: number, unitSystem: UnitSystem = this.unitSystem): string {
        switch (unitSystem) {
            case UnitSystem.Metric:
                return this.toMetric(weight);
            case UnitSystem.Imperial:
                return this.toImperial(weight);
            default:
                throw new Error("No Unit system like the one specified");
        }
    }

    private toMetric(number: number): string {
        return number / this.MASS_KG_LBS + ' kg';
    }

    private toImperial(number: number): string {
        return number * this.MASS_KG_LBS + ' lbs';
    }


}