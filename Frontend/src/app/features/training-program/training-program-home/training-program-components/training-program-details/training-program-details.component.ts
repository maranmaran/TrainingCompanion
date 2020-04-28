import { Component, OnDestroy, OnInit } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { combineLatest, Observable } from 'rxjs';
import { map, switchMap, take } from 'rxjs/operators';
import { TrainingProgramUserService } from 'src/business/services/feature-services/training-program-user.service';
import { getPlaceholderImagePath } from 'src/business/utils/utils';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { AccountType } from 'src/server-models/enums/account-type.enum';
import { SubSink } from 'subsink';
import { UserService } from './../../../../../../business/services/feature-services/user.service';
import { UIService } from './../../../../../../business/services/shared/ui.service';
import { currentUser } from './../../../../../../ngrx/auth/auth.selectors';
import { selectedTrainingProgram } from './../../../../../../ngrx/training-program/training-program/training-program.selectors';
import { TrainingProgramAssignComponent } from './../training-program-assign/training-program-assign.component';

@Component({
  selector: 'app-training-program-details',
  templateUrl: './training-program-details.component.html',
  styleUrls: ['./training-program-details.component.scss']
})
export class TrainingProgramDetailsComponent implements OnInit, OnDestroy {

  trainingProgram$: Observable<TrainingProgram>;
  placeholderImagePath: string;

  step = 0;

  constructor(
    private store: Store<AppState>,
    private trainingProgramUserService: TrainingProgramUserService,
    private UIService: UIService,
    private userService: UserService,
    public mediaObserver: MediaObserver,
    public translateService: TranslateService
  ) { }

  subs = new SubSink();

  showAll = false;

  ngOnInit() {
    this.trainingProgram$ = this.store.select(selectedTrainingProgram);

    this.subs.add(
      this.store.select(activeTheme).subscribe(theme => this.placeholderImagePath = getPlaceholderImagePath(theme))
    )
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  onAssign(event: Event, trainingProgram: TrainingProgram) {
    event.stopPropagation();
    combineLatest(
      this.store.select(currentUser),
      this.store.select(currentUserId)
        .pipe(
          take(1),
          switchMap(id => this.userService.getAll(AccountType.Athlete, id).pipe(take(1))),
      ))
      .pipe(
        take(1),
        map(([currentUser, users]: [CurrentUser, ApplicationUser[]]) => [ currentUser as unknown as ApplicationUser, ...users ])
      )
      .subscribe(users => this.openAssignDialog(trainingProgram, users))
  }

  openAssignDialog(trainingProgram: TrainingProgram, users: ApplicationUser[]) {
    const dialogRef = this.UIService.openDialogFromComponent(TrainingProgramAssignComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      data: { title: 'TRAINING_PROGRAM.ASSIGN', trainingProgram, users },
      panelClass: []
    })

    dialogRef.afterClosed()
      .pipe(take(1))
      .subscribe(_ => { })
  }

}
