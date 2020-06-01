import { TrainingBlockService } from 'src/business/services/feature-services/training-block.service';
import { TrainingBlockDayService } from 'src/business/services/feature-services/training-block-day.service';
import { Component, OnDestroy, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { Store } from '@ngrx/store';
import { combineLatest, Observable, iif } from 'rxjs';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedTrainingId } from 'src/ngrx/training-log/training.selectors';
import { selectedTrainingBlockDay, selectedTrainingBlockDayId } from 'src/ngrx/training-program/training-block-day/training-block-day.selectors';
import { selectedTrainingProgramId } from 'src/ngrx/training-program/training-program/training-program.selectors';
import { TrainingBlockDay, TrainingBlock } from 'src/server-models/entities/training-program.model';
import { SubSink } from 'subsink';
import { clearTrainingState } from './../../../../ngrx/training-log/training.actions';
import { selectedExerciseId } from './../../../../ngrx/training-log/training.selectors';
import { selectedTrainingBlockId } from './../../../../ngrx/training-program/training-block/training-block.selectors';
import { MatTabGroup } from '@angular/material/tabs';
import { filter, switchMap, take, distinct, tap } from 'rxjs/operators';
import { trainingBlockDayFetched } from 'src/ngrx/training-program/training-block-day/training-block-day.actions';
import { trainingBlockFetched } from 'src/ngrx/training-program/training-block/training-block.actions';

@Component({
  selector: 'app-training-program-home',
  templateUrl: './training-program-home.component.html',
  styleUrls: ['./training-program-home.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class TrainingProgramHomeComponent implements OnInit, OnDestroy {

  private _subs = new SubSink();

  blockDay: Observable<TrainingBlockDay>;

  programSelected: boolean
  blockSelected: boolean

  @ViewChild("tabs", { static: true }) tabs: MatTabGroup;

  constructor(
    private store: Store<AppState>,
    public mediaObserver: MediaObserver,
    private blockService: TrainingBlockService,
    private dayService: TrainingBlockDayService,
  ) { }

  ngOnInit(): void {
    this.blockDay = this.store.select(selectedTrainingBlockDay);

    this._subs.add(
      combineLatest(
        this.store.select(selectedTrainingProgramId),
        this.store.select(selectedTrainingBlockId),
      ).subscribe(([program, block]) => {
        let programSelected = !!program;
        let blockSelected = !!program && !!block;

        if (programSelected)
          this.fetchBlockData();

        if (blockSelected)
          this.fetchBlockDaysData();

        setTimeout(_ => {
          this.programSelected = programSelected;
          this.blockSelected = blockSelected;
        })
      })
    );

  }

  ngOnDestroy(): void {
    // because some selects on training state will affect calendar...
    this.store.dispatch(clearTrainingState());
  }

  private _previousProgramId: string;
  fetchBlockData() {
    return this.store.select(selectedTrainingProgramId)
      .pipe(
        take(1),
        filter(id => !!id && id != this._previousProgramId),
        tap(id => this._previousProgramId = id as string),
        switchMap(programId => this.blockService.getAll(programId as string))
      )
      .subscribe((blocks: TrainingBlock[]) => this.store.dispatch(trainingBlockFetched({ entities: blocks })));
  }

  private _previousBlockId: string;
  fetchBlockDaysData() {
    return this.store.select(selectedTrainingBlockId)
      .pipe(
        take(1),
        filter(id => !!id && id != this._previousBlockId),
        tap(id => this._previousBlockId = id as string),
        switchMap(blockId => this.dayService.getAll(blockId as string))
      )
      .subscribe((blocks: TrainingBlockDay[]) => {

        this.store.dispatch(trainingBlockDayFetched({ entities: blocks }))

        setTimeout(_ => this.tabs.selectedIndex = 1);
      });
  }

}
