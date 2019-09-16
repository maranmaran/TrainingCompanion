import { UnitSystemService } from 'src/business/services/shared/unit-system.service';
import { Set } from 'src/server-models/entities/set.model';
import { Component, OnInit, Inject } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { SetService } from 'src/business/services/feature-services/set.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CRUD } from 'src/business/shared/crud.enum';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { UserSettings } from 'src/server-models/entities/user-settings.model';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl, FormArray } from '@angular/forms';
import { currentUser, userSettings } from 'src/ngrx/auth/auth.selectors';
import { take, map } from 'rxjs/operators';
import { selectedExercise } from 'src/ngrx/training-log/exercise/exercise.selectors';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

@Component({
  selector: 'app-set-create-edit',
  templateUrl: './set-create-edit.component.html',
  styleUrls: ['./set-create-edit.component.scss']
})
export class SetCreateEditComponent implements OnInit {

  
  constructor(
    private store: Store<AppState>,
    private unitSystemService: UnitSystemService,
    private setService: SetService,
    protected dialogRef: MatDialogRef<SetCreateEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { title: string,  sets: Set[] }) { }

  form: FormGroup;
  get formControls() { return (<FormArray>this.form.get('sets')).controls; }
  sets: Set[] = [];

  coachId: string;
  settings: UserSettings;
  exerciseType: ExerciseType;
  

  ngOnInit() {
    this.store.select(selectedExercise).pipe(take(1), map(exercise => exercise.exerciseType)).subscribe(type => this.exerciseType = type);
    this.store.select(userSettings).pipe(take(1)).subscribe(settings => this.settings = settings);
    this.store.select(currentUser).pipe(take(1)).subscribe(user => this.coachId = user.id);
    this.sets = [...this.data.sets];

    this.createForm();
    console.log(this.form);
    console.log(this.formControls);
  }

  createForm() {
    const controls = [];
    this.sets.forEach(set => {
      controls.push(
        new FormGroup(this.getControls(set))
      )
    })

    this.form = new FormGroup({
      sets: new FormArray(controls)
    });
  }

  addControl() {
    this.formControls.push(new FormGroup(this.getControls(new Set())));
  }

  removeControl(index: number) {
    (<FormArray>this.form.get('sets')).removeAt(index);
  }

  getControls(set: Set): {[key:string]: AbstractControl} {
    const controls = {};

    // todo.. add weight attribute to application user
    if(this.exerciseType.requiresBodyweight) 
      controls["weight"] = new FormControl({ value: set.weight, disabled: true}, [ Validators.min(0), Validators.max(200)]);

    if(this.exerciseType.requiresReps)
      controls["reps"] = new FormControl(set.reps, [ Validators.min(0), Validators.max(100)]);

    if(this.exerciseType.requiresTime)
      controls["time"] = new FormControl(set.time, [Validators.required]);

    if(this.exerciseType.requiresWeight) {
      let upperLimit = 600;
      if(this.settings.unitSystem == UnitSystem.Imperial) {
        upperLimit = 1200;
      }

      controls["weight"] = new FormControl(0, [ Validators.min(0), Validators.max(upperLimit)]);
    }

    if(this.settings.useRpeSystem) {
      if(this.settings.rpeSystem == RpeSystem.Rir)
        controls["rpe"] = new FormControl((10 - set.rpe), [Validators.required]);


      if(this.settings.rpeSystem == RpeSystem.Rpe)
        controls["rpe"] = new FormControl(set.rpe, [Validators.required]);
    }

    return controls;
  }

  onSubmit() {
     
  }

  onClose(sets?: Set[]) {
    this.dialogRef.close(sets);
  }

 
}