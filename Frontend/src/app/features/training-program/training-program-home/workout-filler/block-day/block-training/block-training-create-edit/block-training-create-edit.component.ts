import { Component, Inject, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ChangeEvent } from '@ckeditor/ckeditor5-angular';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import * as moment from 'moment';
import { take } from 'rxjs/operators';
import { TrainingCreateEditComponent } from 'src/app/features/training-log/training/training-create-edit/training-create-edit.component';
import { applyUserTimezone } from 'src/business/pipes/apply-timezone.pipe';
import { TrainingService } from 'src/business/services/feature-services/training.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { CreateTrainingRequest } from 'src/server-models/cqrs/training/create-training.request';
import { UpdateTrainingRequest } from 'src/server-models/cqrs/training/update-training.request';
import { Training } from 'src/server-models/entities/training.model';

@Component({
  selector: 'app-block-training-create-edit',
  templateUrl: './block-training-create-edit.component.html',
})
export class BlockTrainingCreateEditComponent implements OnInit {

  time: FormControl;
  note: string;
  ckEditor = ClassicEditor;
  ckEditorConfig = {
      toolbar: ['bold', 'link', 'bulletedList', 'undo', 'redo', 'insertTable', 'ImageUpload', 'MediaEmbed']
  };

  constructor(
    private trainingService: TrainingService,
    private dialogRef: MatDialogRef<TrainingCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      title: string,
      action: CRUD.Create | CRUD.Update,
      training: Training,
    }) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    let trainingTime = applyUserTimezone(this.data.training.dateTrained).format('HH:mm');
    this.ckEditor.note = this.data.training.note;

    this.time = new FormControl(trainingTime)
  }
  
  onChange( { editor }: ChangeEvent ) {
    this.note = editor.getData();
  }

  onSubmit() {
    if (!this.time.valid)
      return;

    this.data.training.dateTrained = moment(moment(new Date()).format('L') + ' ' + this.time.value, 'L HH:mm').toDate();
    this.data.training.note = this.note;

    switch (this.data.action) {
      case CRUD.Create:
        return this.create(this.data.training);

      case CRUD.Update:
        return this.edit(this.data.training);

      default:
        throw new Error('Invalid action')
    };
  }

  onClose(training?: Training) {
    this.dialogRef.close(training);
  }

  create(training) {
    const request: CreateTrainingRequest = {
      applicationUserId: training.applicationUserId,
      dateTrained: training.dateTrained,
      trainingBlockDayId: training.trainingBlockDayId
    };

    this.trainingService.create<CreateTrainingRequest>(request).pipe(take(1))
    .subscribe(trainingResponse => {
      this.onClose(trainingResponse as Training);
    }, 
    err => console.log(err))
  }

  edit(training) {
    const request: UpdateTrainingRequest = {
      dateTrained: training.dateTrained,
      id: training.id,
      note: training.note,
      noteRead: false,
      trainingBlockDayId: training.trainingBlockDayId
    }

    this.trainingService.update<UpdateTrainingRequest>(request).pipe(take(1))
    .subscribe(trainingResponse => {
      this.onClose(trainingResponse as Training);
    }, 
    err => console.log(err))
  }
}
