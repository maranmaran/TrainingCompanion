import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { unitSystem } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

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
            case UnitSystem.Metric: // this is by default
                return this.toMetric(weight) + ' kg';
            case UnitSystem.Imperial:
                return this.toImperial(weight) + ' lbs';
            default:
                throw new Error("No Unit system like the one specified");
        }
    }

    public transformWeightToNumber(weight: number, unitSystem: UnitSystem = this.unitSystem): number {
      switch (unitSystem) {
          case UnitSystem.Metric: // this is by default
              return this.toMetric(weight);
          case UnitSystem.Imperial:
              return this.toImperial(weight);
          default:
              throw new Error("No Unit system like the one specified");
      }
  }

    private toMetric(number: number): number {
        return number; // because default.. return same number
    }

    private toImperial(number: number): number {
        return number * this.MASS_KG_LBS;
    }


}
