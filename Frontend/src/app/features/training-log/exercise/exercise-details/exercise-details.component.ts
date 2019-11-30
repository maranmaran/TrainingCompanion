import { Component, OnDestroy, OnInit } from '@angular/core';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import * as _ from "lodash";
import { take } from 'rxjs/operators';
import { ExerciseService } from 'src/business/services/feature-services/exercise.service';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingUpdated } from 'src/ngrx/training-log/training/training.actions';
import { selectedExercise, selectedTraining } from 'src/ngrx/training-log/training/training.selectors';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { Training } from 'src/server-models/entities/training.model';
import { getMediaType } from 'src/server-models/enums/media-type.enum';
import { SubSink } from 'subsink';
import { UnitSystemService } from './../../../../../business/services/shared/unit-system.service';

@Component({
  selector: 'app-exercise-details',
  templateUrl: './exercise-details.component.html',
  styleUrls: ['./exercise-details.component.scss']
})
export class ExerciseDetailsComponent implements OnInit, OnDestroy {

  protected exercise: Exercise;
  private training: Training;
  private subs = new SubSink();

  private userId: string;

  constructor(
    private store: Store<AppState>,
    private unitService: UnitSystemService,
    private exerciseService: ExerciseService
  ) { }

  ngOnInit() {
    this.store.select(currentUserId).pipe(take(1)).subscribe(userId => this.userId = userId);
    this.store.select(selectedTraining).pipe(take(1)).subscribe(training => this.training = _.cloneDeep(training));

    this.subs.add(
      this.store.select(selectedExercise)
        .subscribe(exercise => {
          this.exercise = exercise;
        })
      );
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  get totalVolume() {
    const volume = this.exercise.sets.reduce((total, set) => total + set.volume, 0);
    return this.unitService.transformWeight(volume);
  }

  get projectedMax() {
    const max = this.exercise.sets.reduce((max, set) => set.projectedMax > max ? set.projectedMax : max, 0);
    return this.unitService.transformWeight(max);
  }

  onFileUploaded(fileToUpload: File) {
    this.exerciseService.uploadMedia(this.userId, this.exercise.trainingId, this.exercise.id, fileToUpload, 'jpg', getMediaType(fileToUpload))
      .pipe(take(1))
      .subscribe(
        (media: MediaFile) => {

          var index = this.training.exercises.findIndex(x => x.id == this.exercise.id);
          var exercises: Exercise[] = _.cloneDeep(this.training.exercises);
          exercises[index].media.push(media);
          this.training.media.push(media);

          var updatedTraining: Update<Training> = {
            id: this.training.id,
            changes: {
              media: this.training.media,
              exercises: exercises
            }
          };

          this.store.dispatch(trainingUpdated({ entity: updatedTraining }));
        },
        err => console.log(err)
      );
  }

}
