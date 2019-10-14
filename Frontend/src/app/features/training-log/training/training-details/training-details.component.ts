import { Component, OnDestroy, OnInit } from '@angular/core';
import { ChangeEvent } from '@ckeditor/ckeditor5-angular';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingUpdated } from 'src/ngrx/training-log/training2/training.actions';
import { selectedTraining, sessionVolume } from 'src/ngrx/training-log/training2/training.selectors';
import { UpdateTrainingRequest } from 'src/server-models/cqrs/training/requests/update-training.request';
import { Training } from 'src/server-models/entities/training.model';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-training-details',
  templateUrl: './training-details.component.html',
  styleUrls: ['./training-details.component.scss']
})
export class TrainingDetailsComponent implements OnInit, OnDestroy {


  protected training: Training;
  protected sessionVolume: Observable<number>;
  private subs = new SubSink();

  protected ckEditor = ClassicEditor;
  protected showEditor = false;
  protected ckEditorConfig = {
      toolbar: ['bold', 'link', 'bulletedList', 'undo', 'redo', 'insertTable', 'ImageUpload', 'MediaEmbed']
  };

  constructor(
    private store: Store<AppState>,
    private trainingService: TrainingService
  ) { }

  ngOnInit() {
    this.subs.add(
      this.store.select(selectedTraining)
      .subscribe(training => this.training = training)
    );

    this.sessionVolume = this.store.select(sessionVolume);
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  public note = "";
  public onChange( { editor }: ChangeEvent ) {
    this.note = editor.getData();
  }

  saveNote() {
    const trainingCopy = Object.assign(new Training(), this.training);
    trainingCopy.note = this.note;
    this.saveTraining(trainingCopy)
      .subscribe(
        (training: Training) => {

          this.showEditor = false;

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

  saveMedia() {

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
