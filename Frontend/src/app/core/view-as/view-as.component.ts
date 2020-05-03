import { SubSink } from 'subsink';
import { UserService } from './../../../business/services/feature-services/user.service';
import { AppState } from './../../../ngrx/global-setup.ngrx';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { Store } from '@ngrx/store';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { take, concatMap, filter, tap, map, distinctUntilChanged } from 'rxjs/operators';
import { AccountType } from 'src/server-models/enums/account-type.enum';
import { setViewAs } from 'src/ngrx/auth/auth.actions';
import { Router, ActivatedRoute, RouteConfigLoadEnd, NavigationStart } from '@angular/router';

@Component({
  selector: 'app-view-as',
  templateUrl: './view-as.component.html',
  styleUrls: ['./view-as.component.scss']
})
export class ViewAsComponent implements OnInit {

  viewAsMode = false;
  render = false;

  users: ApplicationUser[] = [];
  user = new FormControl();

  subs = new SubSink();

  constructor(
    private store: Store<AppState>,
    private userService: UserService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.fetchUsers();

    this.subs.add(
      this.onUserChange(),
      this.onCheckIfComponentCanBootstrap()
    )
  }

  // refactor this to take other.. routes and features into account
  // put these routes and features in some data structure.. don't hardcode this 
  onCheckIfComponentCanBootstrap() {

    if (this.router.url.indexOf('training-log') !== -1) {
      this.render = true;
    }

    return this.router.events
      .pipe(
        filter(event => event instanceof NavigationStart),
        map(event => (event as NavigationStart).url.indexOf('training-log') !== -1),
        distinctUntilChanged()
      ).subscribe(render => this.render = render)
  }

  fetchUsers() {
    this.store.select(currentUser)
      .pipe(
        concatMap(user => this.userService.getAll(AccountType.Athlete, user.id)),
        take(1),
      )
      .subscribe(
        (users: ApplicationUser[]) => this.users = users,
        err => console.log(err)
      );
  }

  onUserChange() {
    return this.user.valueChanges.subscribe(user => {

      // dispatch.. view as change
      if (this.user.valid) {
        this.store.dispatch(setViewAs({ entity: user }));
      }
    })
  }

  displayFn = (user: ApplicationUser) => user?.fullName;

  onClear() {
    // dispatch.. end view as
    this.user.setValue(null);
    this.store.dispatch(setViewAs({ entity: null }));
    this.viewAsMode = false;
  }
}
