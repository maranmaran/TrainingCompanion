import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { PersonalBestService } from 'src/business/services/feature-services/personal-best.service';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { selectedExerciseType } from 'src/ngrx/training-log/training.selectors';
import { CreatePersonalBestRequest } from 'src/server-models/cqrs/personal-best/create-personal-best.request';
import { Bodyweight } from 'src/server-models/entities/bodyweight.model';
import { UnitSystem, UnitSystemUnitOfMeasurement } from 'src/server-models/enums/unit-system.enum';
import { latestBodyweight, userSetting } from './../../../../../../ngrx/auth/auth.selectors';
import { PersonalBest } from './../../../../../../server-models/entities/personal-best.model';
import { UserSetting } from './../../../../../../server-models/entities/user-settings.model';

@Component({
  selector: 'app-choose-max-dialog',
  templateUrl: './choose-max-dialog.component.html',
  styleUrls: ['./choose-max-dialog.component.scss']
})
export class ChooseMaxDialogComponent implements OnInit {

  max = new FormControl(0, [Validators.required]);

  _settings: UserSetting;
  _exerciseTypeId: string;
  latestBodyweight: Bodyweight;

  constructor(
    private prService: PersonalBestService,
    private store: Store<AppState>,
    private dialogRef: MatDialogRef<ChooseMaxDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { title: string, systemPR: PersonalBest }) { }

  ngOnInit(): void {
    this.store.select(userSetting).pipe(take(1)).subscribe(setting => this._settings = setting);
    this.store.select(selectedExerciseType).pipe(take(1)).subscribe(type => this._exerciseTypeId = type.id);
    this.store.select(latestBodyweight).pipe(take(1)).subscribe(bw => this.latestBodyweight = bw);

    let max = 0;
    if(this.data.systemPR)
      max = this.data.systemPR.value;

    setTimeout(_ => {
      let upperRange = 600;
      if(this._settings.unitSystem == UnitSystem.Imperial)
        upperRange = 1200;

      this.max.setValue(max);
      this.max.setValidators([Validators.min(0), Validators.max(upperRange)])
    })
  }

  get unitSystemUnitofMeasurement() {
    if (this._settings.unitSystem == UnitSystem.Metric)
      return UnitSystemUnitOfMeasurement.Metric;

    return UnitSystemUnitOfMeasurement.Imperial;
  }

  onClose() {
    this.dialogRef.close(null);
  }

  onSubmit() {
    if(!this.max.valid)
      return;

    // todo
    let request = new CreatePersonalBestRequest({
      value: this.max.value,
      dateAchieved: new Date(),
      reps: 1,
      exerciseTypeId: this._exerciseTypeId,
      unitSystem: this._settings.unitSystem,
      bodyweight: this.latestBodyweight.value,
    });

    this.prService.create(request)
    .pipe(take(1))
    .subscribe(pb => {
      this.dialogRef.close(pb);
    })
  }

}
