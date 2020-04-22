import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedTrainingProgram } from 'src/ngrx/training-program/training-program/training-program.selectors';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';

@Component({
  selector: 'app-training-program-details',
  templateUrl: './training-program-details.component.html',
  styleUrls: ['./training-program-details.component.scss']
})
export class TrainingProgramDetailsComponent implements OnInit {

  trainingProgram$: Observable<TrainingProgram>;

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.trainingProgram$ = this.store.select(selectedTrainingProgram);
  }


}
