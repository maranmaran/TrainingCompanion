import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { userSetting } from 'src/ngrx/auth/auth.selectors';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { UserSetting } from 'src/server-models/entities/user-settings.model';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';
import { AppState } from './../../../../../../../../ngrx/global-setup.ngrx';

@Component({
  selector: 'app-block-exercise-details',
  templateUrl: './block-exercise-details.component.html',
  styleUrls: ['./block-exercise-details.component.scss']
})
export class BlockExerciseDetailsComponent implements OnInit {

  @Input() exercise: Exercise;
  @Output("delete") onDeleteEvent = new EventEmitter<Exercise>()
  @Output("update") onUpdateEvent = new EventEmitter<Exercise>()

  settings: UserSetting;
  previewId?: number;


  get exerciseType(): ExerciseType {
    return this.exercise.exerciseType;
  }

  get rpeLabel() {
    return this.settings.rpeSystem == RpeSystem.Rpe ? 'TRAINING_LOG.SET_RPE' : 'TRAINING_LOG.SET_RIR'
  }

  displayedColumns: string[] = [];

  constructor(
    private store: Store<AppState>
  ) { }

  ngOnInit(): void {
    this.store.select(userSetting).pipe(take(1)).subscribe(settings => this.settings = settings);

    this.getTableColumns();
  }

  getTableColumns() {

    this.displayedColumns.push('name');

    if (this.exerciseType.requiresWeight || this.exerciseType.requiresBodyweight)
      this.displayedColumns.push('weight')

    if (this.exerciseType.requiresReps)
      this.displayedColumns.push('reps')

    if (this.exerciseType.requiresTime)
      this.displayedColumns.push('time')

    if (this.settings.useRpeSystem)
      this.displayedColumns.push('rpe')

    this.displayedColumns.push('actions');
  }

  onUpdateSets(exercise: Exercise) {
    console.log(exercise);

  }

}
