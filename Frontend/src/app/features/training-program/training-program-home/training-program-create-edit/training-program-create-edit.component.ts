import { CreateTrainingProgramRequest } from './../../../../../server-models/cqrs/program-maker/create-training-program.request';
import { Component, OnInit, Inject } from '@angular/core';
import { TrainingProgramService } from 'src/business/services/feature-services/training-program.service';
import { Store, createAction } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CRUD } from 'src/business/shared/crud.enum';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { FormGroup, AbstractControl, FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { take } from 'rxjs/operators';
import { isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { trainingProgramCreated, trainingProgramUpdated } from 'src/ngrx/training-program/training-program.actions';
import { Update } from '@ngrx/entity';
import { UpdateTrainingProgramRequest } from 'src/server-models/cqrs/program-maker/update-training-program.request';

@Component({
  selector: 'app-training-program-create-edit',
  templateUrl: './training-program-create-edit.component.html',
  styleUrls: ['./training-program-create-edit.component.scss']
})
export class TrainingProgramCreateEditComponent implements OnInit {

  constructor(
    private trainingProgramService: TrainingProgramService,
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<TrainingProgramCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      title: string,
      action: CRUD,
      trainingProgram: TrainingProgram
    }) { }

  form: FormGroup;
  private _userId: string;
  trainingProgram: TrainingProgram;

  isMobile: Observable<boolean>;

  ngOnInit() {
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this._userId = user.id);
    this.trainingProgram = this.data.trainingProgram;
    this.trainingProgram.creatorId = this._userId;

    this.isMobile = this.store.select(isMobile);

    this.createForm();
  }

  get name(): AbstractControl { return this.form.get('name'); }
  get description(): AbstractControl { return this.form.get('description'); }
  get image(): AbstractControl { return this.form.get('image'); }

  createForm() {
    this.form = new FormGroup({
      name: new FormControl(this.trainingProgram.name, Validators.required),
      description: new FormControl(this.trainingProgram.description),
      image: new FormControl(this.trainingProgram.imageUrl),
    });
  }

  fileChangeEvent(event) {
    console.log(event);
  }

  onSubmit() {
    if (!this.form.valid)
      return;

    if (this.data.action == CRUD.Create) {
      this.createEntity();
    } else if (this.data.action == CRUD.Update) {
      this.updateEntity();
    }
  }

  onClose(trainingProgram?: TrainingProgram) {
    this.dialogRef.close(trainingProgram);
  }

  createEntity() {
    const request = new CreateTrainingProgramRequest({
      creatorId: this._userId,
      name: this.name.value,
      description: this.description.value,
      image: this.image.value
    })

    this.trainingProgramService.create(request).pipe(take(1))
      .subscribe(
        (trainingProgram: TrainingProgram) => {
          this.store.dispatch(trainingProgramCreated({ entity: trainingProgram }))
          this.onClose(trainingProgram)
        },
        err => console.log(err)
      );
  }

  updateEntity() {
    const request = new UpdateTrainingProgramRequest({
      id: this.trainingProgram.id,
      name: this.name.value,
      description: this.description.value,
      image: this.image.value
    })

    this.trainingProgramService.update(request).pipe(take(1))
      .subscribe(
        (updatedProgram: TrainingProgram) => {

          let updateStatement: Update<TrainingProgram> = {
            id: updatedProgram.id,
            changes: updatedProgram
          };

          this.store.dispatch(trainingProgramUpdated({ entity: updateStatement }))
          this.onClose(updatedProgram)
        },
        err => console.log(err)
      );
  }

}
