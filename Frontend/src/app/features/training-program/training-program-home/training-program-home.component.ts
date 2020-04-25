import { MediaObserver } from '@angular/flex-layout';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { combineLatest } from 'rxjs';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedTrainingId } from 'src/ngrx/training-log/training.selectors';
import { selectedTrainingBlockDayId } from 'src/ngrx/training-program/training-block-day/training-block-day.selectors';
import { selectedTrainingProgramId } from 'src/ngrx/training-program/training-program/training-program.selectors';
import { SubSink } from 'subsink';
import { clearTrainingState } from './../../../../ngrx/training-log/training.actions';
import { selectedExerciseId } from './../../../../ngrx/training-log/training.selectors';
import { selectedTrainingBlockId } from './../../../../ngrx/training-program/training-block/training-block.selectors';

@Component({
  selector: 'app-training-program-home',
  templateUrl: './training-program-home.component.html',
  styleUrls: ['./training-program-home.component.scss']
})
export class TrainingProgramHomeComponent implements OnInit, OnDestroy {

  private _subs = new SubSink();

  programSelected: boolean
  blockSelected: boolean
  blockDaySelected: boolean
  trainingSelected: boolean
  exerciseSelected: boolean

  constructor(
    private store: Store<AppState>,
    public mediaObserver: MediaObserver
  ) { }

  ngOnInit(): void {
    this._subs.add(
      combineLatest(
        this.store.select(selectedTrainingProgramId),
        this.store.select(selectedTrainingBlockId),
        this.store.select(selectedTrainingBlockDayId),
        this.store.select(selectedTrainingId),
        this.store.select(selectedExerciseId),
      ).subscribe(([program, block, blockDay, training, exercise]) => {
        this.programSelected = !!program;
        this.blockSelected = !!program && !!block;
        this.blockDaySelected = !!program && !!block && !!blockDay;
        this.trainingSelected = !!program && !!block && !!blockDay && !!training;
        this.exerciseSelected = !!program && !!block && !!blockDay && !!training && !!exercise;
      })
    );
  }

  ngOnDestroy(): void {
    // because some selects on training state will affect calendar...
    this.store.dispatch(clearTrainingState());
  }

}
