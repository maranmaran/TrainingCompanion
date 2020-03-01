import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import * as moment from 'moment';
import { take } from 'rxjs/operators';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { bodyweightCreated } from 'src/ngrx/bodyweight/bodyweight.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { Bodyweight } from 'src/server-models/entities/bodyweight.model';
import { BodyweightService } from './../../../../../business/services/feature-services/bodyweight.service';

@Component({
  selector: 'app-bodyweight-create-edit',
  templateUrl: './bodyweight-create-edit.component.html',
  providers: [
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
  ]
})
export class BodyweightCreateEditComponent implements OnInit {

  constructor(
    private bodyweightService: BodyweightService,
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<BodyweightCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      title: string,
      action: CRUD
    }) { }

  form: FormGroup;
  private _userId: string;

  ngOnInit() {
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this._userId = user.id);

    this.createForm();
  }

  get date(): AbstractControl { return this.form.get('date'); }

  createForm() {
    this.form = new FormGroup({
      date: new FormControl(moment(new Date()).utc().format('L'), Validators.required),
    });
  }

  onSubmit() {
    if (!this.form.valid)
      return;

    this.createEntity();
  }

  onClose(bodyweight?: Bodyweight) {
    this.dialogRef.close(bodyweight);
  }

  createEntity() {
    this.bodyweightService.create({}).pipe(take(1))
      .subscribe(
        (bodyweight: Bodyweight) => {
          this.store.dispatch(bodyweightCreated({ entity: bodyweight }))
          this.onClose(bodyweight)
        },
        err => console.log(err)
      );
  }

}
