import { Location } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { FormControl } from "@angular/forms";
import { ActivatedRoute, NavigationStart, Router } from "@angular/router";
import { Store } from "@ngrx/store";
import { of } from "rxjs";
import {
  concatMap,
  distinctUntilChanged,
  filter,
  map,
  switchMap,
} from "rxjs/operators";
import { setViewAs } from "src/ngrx/auth/auth.actions";
import { currentUser } from "src/ngrx/auth/auth.selectors";
import { setSelectedTraining } from "src/ngrx/training-log/training.actions";
import { ApplicationUser } from "src/server-models/entities/application-user.model";
import { AccountType } from "src/server-models/enums/account-type.enum";
import { SubSink } from "subsink";
import { UserService } from "./../../../business/services/feature-services/user.service";
import { AppState } from "./../../../ngrx/global-setup.ngrx";

@Component({
  selector: "app-view-as",
  templateUrl: "./view-as.component.html",
  styleUrls: ["./view-as.component.scss"],
})
export class ViewAsComponent implements OnInit {
  viewAsMode = false;
  render = false;

  users: ApplicationUser[] = null;
  user = new FormControl();

  subs = new SubSink();

  constructor(
    private store: Store<AppState>,
    private userService: UserService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.subs.add(
      this.onUserChange(),
      this.onCheckIfComponentCanBootstrap(),
      this.onRouteParamsChange()
    );
  }

  // refactor this to take other.. routes and features into account
  // put these routes and features in some data structure.. don't hardcode this
  onCheckIfComponentCanBootstrap() {
    if (this.router.url.indexOf("training-log") !== -1) {
      this.render = true;
    }

    return this.router.events
      .pipe(
        filter((event) => event instanceof NavigationStart),
        map(
          (event) =>
            (event as NavigationStart).url.indexOf("training-log") !== -1
        ),
        distinctUntilChanged()
      )
      .subscribe((render) => (this.render = render));
  }

  fetchUsers() {
    if (this.users != null) return of(this.users);

    return this.store.select(currentUser).pipe(
      concatMap((user) =>
        this.userService.getAll(AccountType.Athlete, user.id)
      ),
      map((users: ApplicationUser[]) => (this.users = users))
    );
  }

  onRouteParamsChange() {
    return this.activatedRoute.queryParams
      .pipe(
        switchMap((params) =>
          this.fetchUsers().pipe(map((users) => [users, params]))
        )
      )
      .subscribe(([users, params]) => {
        if (params.viewAs) this.setRequestedUserFromUrl(users, params.viewAs);

        if (params.trainingId) this.setRequestedTraining(params.trainingId);
      });
  }

  setRequestedUserFromUrl(users, userId) {
    let user = users.filter((x) => x.id == userId)[0];

    // if user retrieved.. set control which will emit event and trigger view as
    if (user) {
      this.viewAsMode = true;
      this.user.setValue(user);
    }
  }

  setRequestedTraining(id) {
    this.store.dispatch(setSelectedTraining({ id }));
  }

  onUserChange() {
    return this.user.valueChanges.subscribe((user) => {
      // dispatch.. view as change
      if (this.user.valid) {
        this.store.dispatch(setViewAs({ entity: user }));
        this.modifyUrl(user.id);
      }
    });
  }

  displayFn = (user: ApplicationUser) => user?.fullName;

  onClear() {
    // dispatch.. end view as
    this.user.setValue(null);
    this.store.dispatch(setViewAs({ entity: null }));
    this.viewAsMode = false;
    this.modifyUrl(null);
  }

  modifyUrl(userId) {
    let queryParams = Object.assign(
      {},
      this.activatedRoute.snapshot.queryParams
    );
    if (userId) {
      queryParams["viewAs"] = userId;
    }

    const url = this.router
      .createUrlTree([], { relativeTo: this.activatedRoute, queryParams })
      .toString();
    this.location.go(url);
  }
}
