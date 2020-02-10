import { Component, OnDestroy, OnInit } from '@angular/core';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { currentUserId } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingUpdated } from 'src/ngrx/training-log/training/training.actions';
import { selectedTraining, sessionVolume } from 'src/ngrx/training-log/training/training.selectors';
import { UpdateTrainingRequest } from 'src/server-models/cqrs/training/requests/update-training.request';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { Training } from 'src/server-models/entities/training.model';
import { getMediaType } from 'src/server-models/enums/media-type.enum';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-training-details',
  templateUrl: './training-details.component.html',
  styleUrls: ['./training-details.component.scss']
})
export class TrainingDetailsComponent implements OnInit, OnDestroy {

  constructor(
    private store: Store<AppState>,
    private trainingService: TrainingService,
  ) { }


  private userId: string;
  training: Training;
  trainingDetailsData = {
    sessionVolume: new Observable<number>()
  };

  private subs = new SubSink();

  ngOnInit() {

    this.store.select(currentUserId).pipe(take(1)).subscribe(userId => this.userId = userId);

    this.subs.add(
      this.store.select(selectedTraining)
      .subscribe(training => this.training = training)
    );

    this.trainingDetailsData.sessionVolume = this.store.select(sessionVolume);
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
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

          const trainingUpdate: Update<Training> = {
            id: this.training.id,
            changes: {
              media: [...this.training.media, media]
            }
          };

          this.store.dispatch(trainingUpdated({entity: trainingUpdate}));
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
