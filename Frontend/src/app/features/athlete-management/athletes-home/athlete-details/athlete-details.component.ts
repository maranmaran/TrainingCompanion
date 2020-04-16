import { Component, OnInit } from '@angular/core';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map, switchMap, take } from 'rxjs/operators';
import { UserService } from 'src/business/services/feature-services/user.service';
import { athleteUpdated } from 'src/ngrx/athletes/athlete.actions';
import { selectedAthlete } from 'src/ngrx/athletes/athlete.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { getUpdateUserRequest } from 'src/server-models/cqrs/users/update-user.request';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

@Component({
  selector: 'app-athlete-details',
  templateUrl: './athlete-details.component.html',
  styleUrls: ['./athlete-details.component.scss']
})
export class AthleteDetailsComponent implements OnInit {

  athlete$: Observable<ApplicationUser>;

  constructor(
    private userService: UserService,
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.athlete$ = this.store.select(selectedAthlete);
  }

  onSetActive(value: boolean) {

    this.athlete$.pipe(take(1),
      map(athlete => Object.assign({}, athlete)),
      switchMap(athlete => {
        athlete.active = value;
        return this.userService.update(getUpdateUserRequest(athlete));
        },
        athlete => athlete
      ),
    ).subscribe(
        athlete => {
          let updateStatement: Update<ApplicationUser> = {
            id: athlete.id,
            changes: { active: athlete.active }
          }
          this.store.dispatch(athleteUpdated({ entity: updateStatement }));
        },
        err => console.log(err)
      )
  }

}
