import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { combineLatest } from 'rxjs';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedTrainingBlockDayId } from 'src/ngrx/training-program/training-block-day/training-block-day.selectors';
import { selectedTrainingProgramId } from 'src/ngrx/training-program/training-program/training-program.selectors';
import { SubSink } from 'subsink';
import { selectedTrainingBlockId } from './../../../../ngrx/training-program/training-block/training-block.selectors';

@Component({
  selector: 'app-training-program-home',
  templateUrl: './training-program-home.component.html',
  styleUrls: ['./training-program-home.component.scss']
})
export class TrainingProgramHomeComponent implements OnInit {

  private _subs = new SubSink();

  programSelected: boolean
  blockSelected: boolean
  blockDaySelected: boolean

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit(): void {
    this._subs.add(
      combineLatest(
        this.store.select(selectedTrainingProgramId),
        this.store.select(selectedTrainingBlockId),
        this.store.select(selectedTrainingBlockDayId),
      ).subscribe(([program, block, blockDay]) => {
        this.programSelected = !!program;
        this.blockSelected = !!program && !!block;
        this.blockDaySelected = !!program && !!block && !!blockDay;
      })
    );
  }

}
