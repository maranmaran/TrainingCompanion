import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import * as _ from 'lodash-es';
import { take, tap } from 'rxjs/operators';
import { ExerciseService } from 'src/business/services/feature-services/exercise.service';
import { transformWeight } from 'src/business/services/shared/unit-system.service';
import { currentUserId, unitSystem } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingUpdated } from 'src/ngrx/training-log/training.actions';
import { selectedExercise, selectedTraining } from 'src/ngrx/training-log/training.selectors';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { Training } from 'src/server-models/entities/training.model';
import { getMediaType } from 'src/server-models/enums/media-type.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-exercise-details',
  templateUrl: './exercise-details.component.html',
  styleUrls: ['./exercise-details.component.scss']
})
export class ExerciseDetailsComponent implements OnInit, OnDestroy {

  exercise: Exercise;
  private training: Training;
  private subs = new SubSink();

  private userId: string;
  private _unitSystem: UnitSystem

  constructor(
    private store: Store<AppState>,
    private exerciseService: ExerciseService,
    private router: Router
  ) { }

  ngOnInit() {
    this.store.select(currentUserId).pipe(take(1)).subscribe(userId => this.userId = userId);
    this.store.select(unitSystem).pipe(take(1)).subscribe(system => this._unitSystem = system);
    this.store.select(selectedTraining).pipe(take(1)).subscribe(training => this.training = _.cloneDeep(training));

    this.subs.add(
      this.onViewAsTrigger(),

      this.store.select(selectedExercise)
        .subscribe(exercise => {
          this.exercise = exercise;
        })
    );
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  onViewAsTrigger() {
    return this.store.select(selectedTraining)
      .pipe(tap(training => {
        // if we didnt' get training go back to log..
        // this can be case for view as
        // coach has trigger view-as and this selected training is now null because we clear it.. go back to log
        // and fetch only trainings from athlete we are viewing now
        if (!training) {
          this.router.navigate(['/app/training-log']);
        }
      }))
      .subscribe(training => this.training = training);
  }


  get totalVolume() {
    const volume = this.exercise.sets.reduce((total, set) => total + set.volume, 0);
    return transformWeight(volume, this._unitSystem);
  }

  get projectedMax() {
    const max = this.exercise.sets.reduce((max, set) => set.projectedMax > max ? set.projectedMax : max, 0);
    return transformWeight(max, this._unitSystem);
  }

  onFileUploaded(fileToUpload: File) {
    this.exerciseService.uploadMedia(this.userId, this.exercise.id, fileToUpload, 'jpg', getMediaType(fileToUpload))
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
