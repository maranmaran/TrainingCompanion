import { Component, Input, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { forkJoin, of } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { PagingModel } from 'src/app/shared/material-table/table-models/paging.model';
import { ExerciseTypeService } from 'src/business/services/feature-services/exercise-type.service';
import { UIService } from 'src/business/services/shared/ui.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Training } from 'src/server-models/entities/training.model';
import { BlockExerciseCreateEditComponent } from './block-exercise-create-edit/block-exercise-create-edit.component';

@Component({
  selector: 'app-block-training',
  templateUrl: './block-training.component.html',
  styleUrls: ['./block-training.component.scss']
})
export class BlockTrainingComponent implements OnInit {

  @Input() training: Training;
  @Input() order: number;

  private _userId: string;

  constructor(
    private UIService: UIService,
    private translateService: TranslateService,
    private exerciseTypeService: ExerciseTypeService,
    private store: Store<AppState>
  ) { }

  ngOnInit(): void {
    this.store.select(currentUserId).pipe(take(1)).subscribe(id => this._userId = id);
  }

  onAdd(training: Training) {
    var pagingModel = new PagingModel();

    forkJoin(
      this.exerciseTypeService.getPaged(this._userId, pagingModel).pipe(take(1)),
      of(training).pipe(map(training => {
        const len = training.exercises?.length;
        const newExercise = new Exercise();
        newExercise.order = len;
        newExercise.trainingId = training.id;
        newExercise.training = training;

        return newExercise;
      }))
    ).subscribe(([exerciseTypes, exercise]) => {

      const dialogRef = this.UIService.openDialogFromComponent(BlockExerciseCreateEditComponent, {
        height: 'auto',
        width: '98%',
        maxWidth: '50rem',
        autoFocus: false,
        data: { titleExercise: 'TRAINING_LOG.EXERCISE_ADD_TITLE', titleSets: 'TRAINING_LOG.SETS_LABEL', action: CRUD.Create, exercise, exerciseTypes, pagingModel },
        panelClass: []
      });

      dialogRef.afterClosed().pipe(take(1))
        .subscribe((exercise: Exercise) => {
          if (!exercise) return;

          if (!this.training.exercises) this.training.exercises = [];
          this.training.exercises.push(exercise);
        });
    });
  }

}
