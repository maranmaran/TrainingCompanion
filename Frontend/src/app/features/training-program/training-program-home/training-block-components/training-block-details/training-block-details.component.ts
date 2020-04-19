import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedTrainingBlock } from 'src/ngrx/training-program/training-block/training-block.selectors';
import { TrainingBlock } from 'src/server-models/entities/training-program.model';

@Component({
  selector: 'app-training-block-details',
  templateUrl: './training-block-details.component.html',
  styleUrls: ['./training-block-details.component.scss']
})
export class TrainingBlockDetailsComponent implements OnInit {

  trainingBlock$: Observable<TrainingBlock>;
  image: string;

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit() {
    this.trainingBlock$ = this.store.select(selectedTrainingBlock);
  }

}
