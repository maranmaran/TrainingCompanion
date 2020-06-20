import { Component, Inject, OnInit } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { PersonalBestService } from 'src/business/services/feature-services/personal-best.service';
import { CRUD } from 'src/business/shared/crud.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { personalBestCreated, personalBestUpdated } from 'src/ngrx/personal-best/personal-best.actions';
import { PersonalBest } from 'src/server-models/entities/personal-best.model';
import { selectedExerciseType } from './../../../../../ngrx/exercise-type/exercise-type.selectors';
import { ExerciseType } from './../../../../../server-models/entities/exercise-type.model';

@Component({
  selector: 'app-personal-best-create-edit',
  templateUrl: './personal-best-create-edit.component.html',
  styleUrls: ['./personal-best-create-edit.component.scss']
})
export class PersonalBestCreateEditComponent implements OnInit {

  constructor(
    public mediaObserver: MediaObserver,
    private personalBestService: PersonalBestService,
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<PersonalBestCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      title: string,
      action: CRUD,
      personalBest: PersonalBest
    }) { }

  form: FormGroup;
  personalBest: PersonalBest;

  private _latestBodyweight: number = 0;
  private _exerciseType: ExerciseType;
  isMobile: Observable<boolean>;

  ngOnInit() {
    this.personalBest = this.data.personalBest;

    this.getExerciseType();
    // this.getLatestBodyweight();

    this.createForm();
  }

  getExerciseType() {
    this.store.select(selectedExerciseType)
    .pipe(take(1))
    .subscribe(type => this._exerciseType = type);
  }

  getLatestBodyweight() {
    throw Error("Not implemented");
  }

  get dateAchieved(): AbstractControl { return this.form.get('dateAchieved'); }
  get value(): AbstractControl { return this.form.get('value'); }
  get reps(): AbstractControl { return this.form.get('reps'); }
  get time(): AbstractControl { return this.form.get('time'); }
  get distance(): AbstractControl { return this.form.get('distance'); }
  get watts(): AbstractControl { return this.form.get('watts'); }
  get power(): AbstractControl { return this.form.get('power'); }

  createForm() {
    this.form = new FormGroup({
      dateAchieved: new FormControl(this.personalBest.dateAchieved ?? new Date(), Validators.required),
      bodyweight: new FormControl(this.personalBest.bodyweight ?? this._latestBodyweight, Validators.required),
    });

    if(this._exerciseType.requiresReps) {
      this.form.addControl('value', new FormControl(this.personalBest.value ?? 0, Validators.required));
      this.form.addControl('reps', new FormControl(this.personalBest.reps ?? 1, [Validators.required, Validators.min(0)]));
    } else if (this._exerciseType.requiresTime) {
      throw new Error('Not implemented');
    }
    // distance
    // power
  }

  onSubmit() {
    if (!this.form.valid) {
      return;
    }

    this.personalBest.dateAchieved = new Date(this.dateAchieved.value);
    this.personalBest.value = this.value?.value;
    this.personalBest.reps = this.reps?.value;
    this.personalBest.time = this.time?.value;
    this.personalBest.distance = this.distance?.value;
    this.personalBest.watts = this.watts?.value;

    if (this.data.action === CRUD.Create) {
      this.createEntity();
    } else if (this.data.action === CRUD.Update) {
      this.updateEntity();
    }
  }

  onClose(personalBest?: PersonalBest) {
    this.dialogRef.close(personalBest);
  }

  createEntity() {
    this.personalBestService.create(this.personalBest).pipe(take(1))
      .subscribe(
        (personalBest: PersonalBest) => {
          this.store.dispatch(personalBestCreated({ entity: personalBest }));
          this.onClose(personalBest);
        },
        err => console.log(err)
      );
  }

  updateEntity() {
    this.personalBestService.update(this.personalBest).pipe(take(1))
      .subscribe(
        () => {

          const updateStatement: Update<PersonalBest> = {
            id: this.personalBest.id,
            changes: this.personalBest
          };

          this.store.dispatch(personalBestUpdated({ entity: updateStatement }));
          this.onClose(this.personalBest);
        },
        err => console.log(err)
      );
  }

}
