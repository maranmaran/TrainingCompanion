import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MomentDateAdapter, MAT_MOMENT_DATE_FORMATS } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_LOCALE, MAT_DATE_FORMATS } from '@angular/material/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { CRUD } from 'src/business/shared/crud.enum';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { bodyweightCreated, bodyweightUpdated } from 'src/ngrx/bodyweight/bodyweight.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { isMobile } from 'src/ngrx/user-interface/ui.selectors';
import { Bodyweight } from 'src/server-models/entities/bodyweight.model';
import { BodyweightService } from './../../../../../business/services/feature-services/bodyweight.service';
import { Update } from '@ngrx/entity';
import * as moment from 'moment';

@Component({
  selector: 'app-bodyweight-create-edit',
  templateUrl: './bodyweight-create-edit.component.html',
  providers: [
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS] },
  ]
})
export class BodyweightCreateEditComponent implements OnInit {

  constructor(
    private bodyweightService: BodyweightService,
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<BodyweightCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      title: string,
      action: CRUD,
      bodyweight: Bodyweight
    }) { }

  form: FormGroup;
  private _userId: string;
  bodyweight: Bodyweight;

  isMobile: Observable<boolean>;

  ngOnInit() {
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this._userId = user.id);
    this.bodyweight = this.data.bodyweight;
    this.bodyweight.userId = this._userId;

    this.isMobile = this.store.select(isMobile);

    this.createForm();
  }

  get date(): AbstractControl { return this.form.get('date'); }
  get value(): AbstractControl { return this.form.get('value'); }

  createForm() {
    this.form = new FormGroup({
      date: new FormControl(this.bodyweight.date, Validators.required),
      value: new FormControl(this.bodyweight.value, Validators.required),
    });
  }


  onSubmit() {
    if (!this.form.valid)
      return;

    this.bodyweight.value = this.value.value;
    this.bodyweight.date = new Date(this.date.value);

    if(this.data.action == CRUD.Create) {
      this.createEntity();
    } else if(this.data.action == CRUD.Update) {
      this.updateEntity();
    }
  }

  onClose(bodyweight?: Bodyweight) {
    this.dialogRef.close(bodyweight);
  }

  createEntity() {
    this.bodyweightService.create(this.bodyweight).pipe(take(1))
      .subscribe(
        (bodyweight: Bodyweight) => {
          this.store.dispatch(bodyweightCreated({ entity: bodyweight }))
          this.onClose(bodyweight)
        },
        err => console.log(err)
      );
  }

  updateEntity() {
    this.bodyweightService.update(this.bodyweight).pipe(take(1))
      .subscribe(
        (bodyweight: Bodyweight) => {

          let updateStatement: Update<Bodyweight> = {
            id: bodyweight.id,
            changes: bodyweight
          };

          this.store.dispatch(bodyweightUpdated({ entity: updateStatement }))
          this.onClose(bodyweight)
        },
        err => console.log(err)
      );
  }

}
