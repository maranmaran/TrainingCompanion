import { Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { MatTabGroup } from '@angular/material/tabs';
import { Store } from '@ngrx/store';
import { combineLatest, Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { TrainingBlockDayService } from 'src/business/services/feature-services/training-block-day.service';
import { TrainingBlockService } from 'src/business/services/feature-services/training-block.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingBlockDayFetched } from 'src/ngrx/training-program/training-block-day/training-block-day.actions';
import { selectedTrainingBlockDay } from 'src/ngrx/training-program/training-block-day/training-block-day.selectors';
import { trainingBlockFetched } from 'src/ngrx/training-program/training-block/training-block.actions';
import { selectedTrainingProgramId } from 'src/ngrx/training-program/training-program/training-program.selectors';
import { TrainingBlock, TrainingBlockDay } from 'src/server-models/entities/training-program.model';
import { SubSink } from 'subsink';
import { TrainingProgramUserService } from './../../../../business/services/feature-services/training-program-user.service';
import { clearTrainingState } from './../../../../ngrx/training-log/training.actions';
import { selectedTrainingBlockId } from './../../../../ngrx/training-program/training-block/training-block.selectors';
import { trainingProgramUsersFetched } from './../../../../ngrx/training-program/training-program-user/training-program-user.actions';
import { TrainingProgramUser } from './../../../../server-models/entities/training-program.model';

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
    private programUserService: TrainingProgramUserService
  ) { }

  ngOnInit(): void {
    this.blockDay = this.store.select(selectedTrainingBlockDay);

    this._subs.add(
      combineLatest(
        this.store.select(selectedTrainingProgramId),
        this.store.select(selectedTrainingBlockId),
      ).subscribe(([programId, blockId]) => {
        let programSelected = !!programId;
        let blockSelected = !!programId && !!blockId;

        if (programSelected)
          this.resolveProgramData(programId as string);

        if (blockSelected)
          this.fetchBlockDaysData(blockId as string);

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

  /**
   * Resolves necessary selected program data
   * Training program blocks
   * Training program users (assigned users)
   */
  private _previousProgramId: string;
  resolveProgramData(id: string) {
    if (id == this._previousProgramId)
      return;

    this._previousProgramId = id;

    combineLatest(
      this.blockService.getAll(id as string),
      this.programUserService.getAll(id as string)
    ).pipe(
      take(1),
    ).subscribe(
      ([blocks, users]) => {
        this.store.dispatch(trainingBlockFetched({ entities: blocks as TrainingBlock[] }));
        this.store.dispatch(trainingProgramUsersFetched({ entities: users as TrainingProgramUser[] }));
      }
    )
  }

  /**Resolves necessary training program blocks data
   * Fetches training program block days data...
   */
  private _previousBlockId: string;
  fetchBlockDaysData(id: string) {
    if (id == this._previousBlockId)
      return;

    this._previousBlockId = id;

    return this.dayService.getAll(id)
      .subscribe((blocks: TrainingBlockDay[]) => {
        this.store.dispatch(trainingBlockDayFetched({ entities: blocks }))
        setTimeout(_ => this.tabs.selectedIndex = 1);
      });
  }

}
