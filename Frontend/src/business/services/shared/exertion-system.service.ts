import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/app/app.state';
import { exertionSystem } from 'src/ngrx/auth/auth.selectors';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';

export class ExertionSystemService {

  private exertionSystem: RpeSystem;

  constructor(
    private store: Store<AppState>
  ) {
    this.store.select(exertionSystem).pipe(take(1)).subscribe(system => this.exertionSystem = system);
  }

  public transform(exertion): number {

    if(this.exertionSystem == RpeSystem.Rpe) {
      if(exertion < 5) { // rir
        return 10 - exertion;
      }
    }

    if(this.exertionSystem == RpeSystem.Rir) {
      if(exertion > 5) { // rpe
        return 10 - exertion;
      }
    }

    return exertion;
  }

  // rpe 9 to rir 1
  // rir 2 to rpe 8
}
