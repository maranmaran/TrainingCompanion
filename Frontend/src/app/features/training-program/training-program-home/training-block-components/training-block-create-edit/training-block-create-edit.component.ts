import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { TrainingBlockService } from 'src/business/services/feature-services/training-block.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingBlockCreated, trainingBlockUpdated } from 'src/ngrx/training-program/training-block/training-block.actions';
import { isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { CreateTrainingBlockRequest } from 'src/server-models/cqrs/training-program/create-training-program.request';
import { TrainingBlock } from 'src/server-models/entities/training-program.model';
import { UpdateTrainingBlockRequest } from '../../../../../../server-models/cqrs/training-program/update-training-program.request';
import { CRUD } from './../../../../../../business/shared/crud.enum';
import { selectedTrainingProgramId } from './../../../../../../ngrx/training-program/training-program/training-program.selectors';

@Component({
  selector: 'app-training-block-create-edit',
  templateUrl: './training-block-create-edit.component.html',
  styleUrls: ['./training-block-create-edit.component.scss']
})
export class TrainingBlockCreateEditComponent implements OnInit {

  constructor(
    private trainingBlockService: TrainingBlockService,
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<TrainingBlockCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      title: string,
      action: CRUD,
      trainingBlock: TrainingBlock
    }) { }

  form: FormGroup;
  private _programId: string;
  trainingBlock: TrainingBlock;

  crud = CRUD;

  isMobile: Observable<boolean>;

  ngOnInit() {
    this.store.select(selectedTrainingProgramId).pipe(take(1)).subscribe(programId => this._programId = programId as string);
    this.trainingBlock = this.data.trainingBlock;
    this.trainingBlock.trainingProgramId = this._programId;

    this.isMobile = this.store.select(isMobile);

    this.createForm();
  }

  get name(): AbstractControl { return this.form.get('name'); }
  get description(): AbstractControl { return this.form.get('description'); }
  get durationInDays(): AbstractControl { return this.form.get('durationInDays'); }

  createForm() {
    this.form = new FormGroup({
      name: new FormControl(this.trainingBlock.name, Validators.required),
      description: new FormControl(this.trainingBlock.description),
      durationInDays: new FormControl(this.trainingBlock.durationInDays, Validators.required),
    });
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

  onClose(trainingBlock?: TrainingBlock) {
    this.dialogRef.close(trainingBlock);
  }

  createEntity() {
    const request = new CreateTrainingBlockRequest({
      trainingProgramId: this._programId,
      name: this.name.value,
      order: this.data.trainingBlock.order,
      description: this.description.value,
      durationInDays: this.durationInDays.value
    })

    this.trainingBlockService.create(request).pipe(take(1))
      .subscribe(
        (trainingBlock: TrainingBlock) => {
          this.store.dispatch(trainingBlockCreated({ entity: trainingBlock }))
          this.onClose(trainingBlock)
        },
        err => console.log(err)
      );
  }

  updateEntity() {
    const request = new UpdateTrainingBlockRequest({
      id: this.trainingBlock.id,
      name: this.name.value,
      description: this.description.value,
    })

    this.trainingBlockService.update(request).pipe(take(1))
      .subscribe(
        (updatedProgram: TrainingBlock) => {

          let updateStatement: Update<TrainingBlock> = {
            id: updatedProgram.id,
            changes: updatedProgram
          };

          this.store.dispatch(trainingBlockUpdated({ entity: updateStatement }))
          this.onClose(updatedProgram)
        },
        err => console.log(err)
      );
  }

}
