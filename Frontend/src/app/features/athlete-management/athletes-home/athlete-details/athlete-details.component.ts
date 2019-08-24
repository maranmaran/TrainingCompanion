import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { map, switchMap, take } from 'rxjs/operators';
import { UserService } from 'src/business/services/user.service';
import { athleteUpdated } from 'src/ngrx/athletes/athlete.actions';
import { selectedAthlete } from 'src/ngrx/athletes/athlete.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { GetUpdateUserRequest } from 'src/server-models/cqrs/users/requests/update-user.request';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

@Component({
  selector: 'app-athlete-details',
  templateUrl: './athlete-details.component.html',
  styleUrls: ['./athlete-details.component.scss']
})
export class AthleteDetailsComponent implements OnInit {

  protected athlete$: Observable<ApplicationUser>;
  
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
        console.log(GetUpdateUserRequest(athlete));
        return this.userService.update(GetUpdateUserRequest(athlete));
      })).subscribe(
        (athlete: ApplicationUser) => {
          this.store.dispatch(athleteUpdated({athlete}));
        },
        err => console.log(err)
      )
 }

}
