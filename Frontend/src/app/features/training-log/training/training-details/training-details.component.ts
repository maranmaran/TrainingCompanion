import { Component, OnInit, Input } from '@angular/core';
import { Training } from 'src/server-models/entities/training.model';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Store } from '@ngrx/store';
import { selectedTraining } from 'src/ngrx/training-log/training/training.selectors';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-training-details',
  templateUrl: './training-details.component.html',
  styleUrls: ['./training-details.component.scss']
})
export class TrainingDetailsComponent implements OnInit {
  
  protected training: Training;

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.store.select(selectedTraining).pipe(take(1))
    .subscribe(training => this.training = training);
  }

}
