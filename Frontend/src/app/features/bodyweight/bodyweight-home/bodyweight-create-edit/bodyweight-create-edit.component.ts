import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
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
      action: CRUD,
      bodyweight: Bodyweight
    }) { }

  form: FormGroup;
  private _userId: string;
  bodyweight: Bodyweight;

  ngOnInit() {
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this._userId = user.id);
    this.bodyweight = this.data.bodyweight;
    this.bodyweight.userId = this._userId;

    this.createForm();
  }

  get date(): AbstractControl { return this.form.get('date'); }
  get value(): AbstractControl { return this.form.get('value'); }

  createForm() {
    this.form = new FormGroup({
      date: new FormControl(new Date(), Validators.required),
      value: new FormControl(this.bodyweight.value, Validators.required),
    });
  }

  onSubmit() {
    if (!this.form.valid)
      return;

    this.bodyweight.value = this.value.value;
    this.bodyweight.date = new Date(this.date.value);

    this.createEntity();
  }

  onClose(bodyweight?: Bodyweight) {
    this.dialogRef.close(bodyweight);
  }

  createEntity() {
    this.bodyweightService.create(this.bodyweight).pipe(take(1))
      .subscribe(
        (bodyweight: Bodyweight) => {
          console.log(bodyweight)
          this.store.dispatch(bodyweightCreated({ entity: bodyweight }))
          this.onClose(bodyweight)
        },
        err => console.log(err)
      );
  }

}
