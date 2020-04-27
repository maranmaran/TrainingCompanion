import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { switchMap, take } from 'rxjs/operators';
import { TrainingProgramUserService } from 'src/business/services/feature-services/training-program-user.service';
import { getPlaceholderImagePath } from 'src/business/utils/utils';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { activeTheme } from 'src/ngrx/user-interface/ui.selectors';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { AccountType } from 'src/server-models/enums/account-type.enum';
import { SubSink } from 'subsink';
import { UserService } from './../../../../../../business/services/feature-services/user.service';
import { UIService } from './../../../../../../business/services/shared/ui.service';
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

  constructor(
    private store: Store<AppState>,
    private trainingProgramUserService: TrainingProgramUserService,
    private UIService: UIService,
    private userService: UserService
  ) { }

  subs = new SubSink();

  ngOnInit() {
    this.trainingProgram$ = this.store.select(selectedTrainingProgram);

    this.subs.add(
      this.store.select(activeTheme).subscribe(theme => this.placeholderImagePath = getPlaceholderImagePath(theme))
    )
  }


  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }


  onAssign(trainingProgram: TrainingProgram) {
    this.store.select(currentUserId)
      .pipe(
        take(1),
        switchMap(id => this.userService.getAll(AccountType.Athlete, id).pipe(take(1)))
      ).subscribe((users: ApplicationUser[]) => this.openAssignDialog(trainingProgram, users));
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
