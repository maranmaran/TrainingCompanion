import { switchMap, take, map, concatMap } from 'rxjs/operators';
import { AthletesService } from './../../../../../business/services/athletes.service';
import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activateAthlete, deactivateAthlete } from 'src/ngrx/athletes/athlete.actions';
import { selectedAthlete } from 'src/ngrx/athletes/athlete.selectors';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

@Component({
  selector: 'app-athlete-details',
  templateUrl: './athlete-details.component.html',
  styleUrls: ['./athlete-details.component.scss']
})
export class AthleteDetailsComponent implements OnInit {

  protected athlete$: Observable<ApplicationUser>;
  
  constructor(
    private athleteService: AthletesService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.athlete$ = this.store.select(selectedAthlete);
  }

  onSetActive(value: boolean) {
    this.athlete$.pipe(take(1),
      map(athlete => athlete.id),
      switchMap(athleteId => {
        return this.athleteService.setActive(athleteId, value)
      })).subscribe(
        () => {
          value && this.store.dispatch(activateAthlete());
          !value && this.store.dispatch(deactivateAthlete());
        },
        err => console.log(err)
      )
  }

}
