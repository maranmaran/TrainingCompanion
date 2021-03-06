import { MediaFile } from './../../../../../server-models/entities/media-file.model';
import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { take, tap, map } from 'rxjs/operators';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { setTrainingMedia, trainingUpdated } from 'src/ngrx/training-log/training.actions';
import { selectedTraining, trainingMedia, trainingMetrics } from 'src/ngrx/training-log/training.selectors';
import { UpdateTrainingRequest } from 'src/server-models/cqrs/training/update-training.request';
import { Training } from 'src/server-models/entities/training.model';
import { getMediaType } from 'src/server-models/enums/media-type.enum';
import { SubSink } from 'subsink';
import { GetTrainingMetricsResponse } from 'src/server-models/cqrs/report/get-training-metrics.response';
import { exerciseCount } from 'src/ngrx/exercise/exercise.selectors';

@Component({
  selector: 'app-training-details',
  templateUrl: './training-details.component.html',
  styleUrls: ['./training-details.component.scss']
})
export class TrainingDetailsComponent implements OnInit, AfterViewInit, OnDestroy {

  constructor(
    private store: Store<AppState>,
    private trainingService: TrainingService,
    private router: Router
  ) { }


  userId: string;

  training: Training;
  media: MediaFile[];
  metrics: GetTrainingMetricsResponse;
  exerciseCount: number;

  private subs = new SubSink();

  ngOnInit() {

    this.store.select(currentUserId)
    .pipe(
      take(1)
    ).subscribe(userId => this.userId = userId);
    
    this.store.select(trainingMedia)
    .pipe(
      take(1), 
      map(media => media ?? [])
    ).subscribe(media => this.media = [...media]);

    this.store.select(trainingMetrics)
    .pipe(
      take(1), 
      map(metrics => metrics ?? null)
    ).subscribe(metrics => this.metrics = metrics as GetTrainingMetricsResponse);

    this.store.select(exerciseCount).pipe(take(1)).subscribe(count => this.exerciseCount = count);

    this.subs.add(
      this.onViewAsTrigger()
    );

  }

  // Like - LIFT-79 task 
  // Workaround - https://github.com/angular/components/issues/13870
  // tslint:disable-next-line: member-ordering
  disableAnimation = true;
  ngAfterViewInit(): void {
    // timeout required to avoid the dreaded 'ExpressionChangedAfterItHasBeenCheckedError'
    setTimeout(() => this.disableAnimation = false);
  }

  ngOnDestroy(): void {
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

  saveNote(note: string) {
    const trainingCopy = Object.assign(new Training(), this.training);
    trainingCopy.note = note;

    this.saveTraining(trainingCopy)
      .subscribe(
        (training: Training) => {

          const trainingUpdate: Update<Training> = {
            id: training.id,
            changes: {
              note: training.note,
              noteRead: training.noteRead
            }
          };

          this.store.dispatch(trainingUpdated({ entity: trainingUpdate }));
        },
        err => console.log(err)
      );
  }

  onFileUploaded(fileToUpload: File) {
    this.trainingService.uploadMedia(this.userId, this.training.id, fileToUpload, 'jpg', getMediaType(fileToUpload))
      .pipe(take(1))
      .subscribe(
        (media: MediaFile) => {

          this.media = [...this.media, media];

          this.store.dispatch(setTrainingMedia({ id: this.training.id, media: this.media }));
        },
        err => console.log(err)
      );
  }

  saveTraining(training: Training) {

    const request = new UpdateTrainingRequest();
    request.id = training.id;
    request.note = training.note;
    request.noteRead = training.noteRead;

    return this.trainingService.update<UpdateTrainingRequest>(request)
      .pipe(take(1));
  }

}
