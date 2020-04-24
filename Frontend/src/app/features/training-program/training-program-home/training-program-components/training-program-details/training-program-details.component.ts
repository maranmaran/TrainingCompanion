import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { TrainingProgramUserService } from 'src/business/services/feature-services/training-program-user.service';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedTrainingProgram } from 'src/ngrx/training-program/training-program/training-program.selectors';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { CreateTrainingProgramUserRequest } from './../../../../../../server-models/cqrs/training-program/create-training-program-user.request';

@Component({
  selector: 'app-training-program-details',
  templateUrl: './training-program-details.component.html',
  styleUrls: ['./training-program-details.component.scss']
})
export class TrainingProgramDetailsComponent implements OnInit {

  trainingProgram$: Observable<TrainingProgram>;

  constructor(
    private store: Store<AppState>,
    private trainingProgramUserService: TrainingProgramUserService
  ) { }


  userid: string;

  ngOnInit() {
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this.userid = id);
    this.trainingProgram$ = this.store.select(selectedTrainingProgram);
  }

  onAssign(trainingProgram: TrainingProgram) {
    // get..date from some kind of dialog or something
    // get..user from some kind of dialog or something

    var request = new CreateTrainingProgramUserRequest({
      userId: this.userid,
      startDate: new Date(),
      programId: trainingProgram.id
    });

    this.trainingProgramUserService.create(request).pipe(take(1)).subscribe(
      _ => console.log('success'),
      err => console.log(err)
    )
  }


}
