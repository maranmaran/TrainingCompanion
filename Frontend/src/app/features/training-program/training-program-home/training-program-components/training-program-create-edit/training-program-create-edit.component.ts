import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { TrainingProgramService } from 'src/business/services/feature-services/training-program.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { getPlaceholderImagePath } from 'src/business/utils/utils';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingProgramCreated, trainingProgramUpdated } from 'src/ngrx/training-program/training-program/training-program.actions';
import { activeTheme, isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { UpdateTrainingProgramRequest } from 'src/server-models/cqrs/training-program/update-training-program.request';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { SubSink } from 'subsink';
import { CreateTrainingProgramRequest } from '../../../../../../server-models/cqrs/training-program/create-training-program.request';

@Component({
  selector: 'app-training-program-create-edit',
  templateUrl: './training-program-create-edit.component.html',
  styleUrls: [
    './training-program-create-edit.component.scss',
    './../training-program-details/basic-details/basic-details.component.scss'
  ]
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
  placeholderImagePath: string;

  isMobile: Observable<boolean>;
  subs = new SubSink();

  ngOnInit() {
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this._userId = user.id);
    this.trainingProgram = this.data.trainingProgram;
    this.trainingProgram.creatorId = this._userId;

    this.isMobile = this.store.select(isMobile);

    this.subs.add(
      this.store.select(activeTheme).subscribe(theme => this.placeholderImagePath = getPlaceholderImagePath(theme))
    )

    this.createForm();
  }

  get name(): AbstractControl { return this.form.get('name'); }
  get description(): AbstractControl { return this.form.get('description'); }

  createForm() {
    this.form = new FormGroup({
      name: new FormControl(this.trainingProgram.name, Validators.required),
      description: new FormControl(this.trainingProgram.description),
    });
  }

  fileChangeEvent(files: FileList) {
    if(!files.item(0)) return;

    let file = files.item(0);
    // this.trainingProgram.imageUrl = URL.createObjectURL(file);

    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => this.trainingProgram.imageUrl = reader.result as string;
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
      image: this.trainingProgram.imageUrl
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
      image: this.trainingProgram.imageUrl
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
