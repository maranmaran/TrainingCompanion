import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Update } from '@ngrx/entity';
import { Store } from '@ngrx/store';
import { Guid } from 'guid-typescript';
import * as _ from 'lodash-es';
import { noop, of } from 'rxjs';
import { switchMap, take, tap, map } from 'rxjs/operators';
import { SetService } from 'src/business/services/feature-services/set.service';
import { transformWeightToNumber } from 'src/business/services/shared/unit-system.service';
import { userSetting } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { trainingUpdated } from 'src/ngrx/training-log/training.actions';
import { selectedExercise, selectedTraining } from 'src/ngrx/training-log/training.selectors';
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { Set } from 'src/server-models/entities/set.model';
import { Training } from 'src/server-models/entities/training.model';
import { UserSetting } from 'src/server-models/entities/user-settings.model';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';
import { UIService } from './../../../../../business/services/shared/ui.service';
import { UpdateManySetsRequest } from './../../../../../server-models/cqrs/set/update-many-sets.request';
import { Exercise } from './../../../../../server-models/entities/exercise.model';
import { PersonalBest } from './../../../../../server-models/entities/personal-best.model';
import { UnitSystemUnitOfMeasurement } from './../../../../../server-models/enums/unit-system.enum';
import { ChooseMaxDialogComponent } from './choose-max-dialog/choose-max-dialog.component';

@Component({
  selector: 'app-set-create-edit',
  templateUrl: './set-create-edit.component.html',
  styleUrls: ['./set-create-edit.component.scss']
})
export class SetCreateEditComponent implements OnInit {


  constructor(
    private store: Store<AppState>,
    private setService: SetService,
    private dialogRef: MatDialogRef<SetCreateEditComponent>,
    private UIService: UIService,
    @Inject(MAT_DIALOG_DATA) public data: { action, title: string, sets: Set[], prs: PersonalBest[] }) { }

  setFormGroups: FormGroup[] = [];
  // get formControls() { return (<FormArray>this.form.get('sets')).controls; }
  sets: Set[] = [];

  settings: UserSetting;
  exerciseType: ExerciseType;
  exerciseId: string;

  userMaxControl: FormControl;

  setAttributes = false;

  ngOnInit() {
    this.sets = [...this.data.sets];
    this.store.select(userSetting).pipe(take(1)).subscribe(settings => this.settings = Object.assign(new UserSetting(), settings));
    this.store.select(selectedExercise).pipe(take(1)).subscribe(exercise => {
      this.exerciseId = exercise.id;
      this.exerciseType = exercise.exerciseType
    });

    setTimeout(_ => {
      if (this.settings.usePercentages)
        this.setUserMax().subscribe(noop);

      this.createForms();
    });
  }

  createForms() {
    this.sets.forEach(set => {
      this.setFormGroups.push(
        new FormGroup(this.getControls(set))
      )
    });
  }

  onSetRpeControl(event: MatSlideToggleChange, index: number) {
    if (!event.checked) {
    
      this.setFormGroups[index].removeControl('rpe');
      this.setFormGroups[index].removeControl('rir');
    
    } else {

      if (this.settings.rpeSystem == RpeSystem.Rpe) {
        this.setFormGroups[index].addControl('rpe', new FormControl("5", [Validators.min(0), Validators.max(100)]));
      } else {
        this.setFormGroups[index].addControl('rir', new FormControl("5", [Validators.min(0), Validators.max(100)]));
      }

      this.setFormGroups[index].disable();
    }
  }

  onUsePercentage(event: MatSlideToggleChange, index: number) {

    if (event.checked) {

      let setPercentageControl = (response) => {
        if (response) {
          this.setFormGroups[index].removeControl('weight');
          this.setFormGroups[index].addControl('percentage', new FormControl(0, [Validators.required, Validators.min(0), Validators.max(100)]));
          this.setFormGroups[index].disable();
        } else {
          event.source.checked = false;
        }
      }

      // check for one rep max...
      if (this.userMaxControl == null) {
        this.setUserMax().subscribe(setPercentageControl);
      } else {
        setPercentageControl(true);
      }

    } else {
      this.setFormGroups[index].addControl('weight', new FormControl(0, [Validators.required, Validators.min(0), Validators.max(200)]));
      this.setFormGroups[index].removeControl('percentage');
      this.setFormGroups[index].disable();

      if (!this.checkForPercentageControls()) {
        this.userMaxControl = null;
      }
    }

  }

  checkForPercentageControls() {
    let result = false;
    this.setFormGroups.forEach(group => {
      result = !!group['percentage']
    });

    return result;
  }

  //#region USER MAX

  /** User can't use percentages if he doesn't have at least one PR defined..
   * He can either use HIS PR or opt to using projected max from us
   * But if none of those exist he must manually give us PR or he can't use percentages
   * He should be able to opt out of percentages and use weight for example in case he doesn't know max
   */
  setUserMax() {
    let userPR = this.data.prs[0];
    let systemPR = this.data.prs[1];

    if (!userPR) {
      return this.onSetMaxDialog(systemPR);
    } else {
      this.setUserMaxControl(userPR.value);
    }

    return of(null);
  }

  setUserMaxControl(value: number) {
    value = transformWeightToNumber(value, this.settings.unitSystem);
    let validators = [Validators.required, Validators.min(0), Validators.max(this.weightUpperLimit)]

    this.userMaxControl = new FormControl(value, validators);
  }

  onSetMaxDialog(systemPR: PersonalBest) {

    const dialogRef = this.UIService.openDialogFromComponent(ChooseMaxDialogComponent, {
      height: 'auto',
      width: '98%',
      maxWidth: '20rem',
      autoFocus: false,
      disableClose: true,
      data: {
        title: 'PERSONAL_BEST.SET_MAX',
        systemPR
      },
      panelClass: ['choose-max-dialog-container', "dialog-container"],
    })

    return dialogRef.afterClosed().pipe(
      take(1),
      tap(response => {
        if (!response) {
          this.userMaxControl = null;
          this.settings.usePercentages = false;
        } else {
          this.setUserMaxControl(response.value);
        }
      }))

  }
  //#endregion

  addGroup(set: Set = null) {

    set = set || new Set();

    const controls = this.getControls(set);
    const newSetFormGroup = new FormGroup(controls);

    this.setFormGroups.push(newSetFormGroup);
  }

  removeGroup(index: number) {
    this.setFormGroups.splice(index, 1);
  }

  copyDown(index: number) {
    const setGroup = this.setFormGroups[index];
    let nextGroup = this.setFormGroups[index + 1];

    const set = this.getSet(setGroup);
    if (nextGroup) {
      // update
      set.id = nextGroup.controls["id"].value;

      const groupControls = this.getControls(set);
      nextGroup = new FormGroup(groupControls);

      this.setFormGroups[index + 1] = nextGroup;
    } else {
      set.id = Guid.createEmpty().toString();
      this.addGroup(set);
    }
  }

  getControls(set: Set): { [key: string]: AbstractControl } {
    const controls = {};

    controls["id"] = new FormControl(set.id);

    if (this.exerciseType.requiresReps)
      controls["reps"] = new FormControl(set.reps, [Validators.required, Validators.min(0), Validators.max(100)]);

    if (this.exerciseType.requiresTime)
      controls["time"] = new FormControl(set.time, [Validators.required]);

    // todo.. add weight attribute to application user
    if (this.exerciseType.requiresBodyweight)
      controls["weight"] = new FormControl(set.weight, [Validators.required, Validators.min(0), Validators.max(200)]);

    if (this.exerciseType.requiresWeight && !this.exerciseType.requiresBodyweight) {
      if (!this.settings.usePercentages) {
        controls["weight"] = new FormControl(set.weight, [Validators.required, Validators.min(0), Validators.max(this.weightUpperLimit)]);
      } else {
        // todo calculate percentage from 1 rep max and weight
        controls["percentage"] = new FormControl(set.percentage, [Validators.required, Validators.min(0), Validators.max(100)]);
      }
    }

    if (this.settings.useRpeSystem) {
      if (this.settings.rpeSystem == RpeSystem.Rir) {
        let val = set.rir ? set.rir : 10 - set.rpe;
        controls["rir"] = new FormControl(val.toString(), [Validators.required, Validators.min(0), Validators.max(10)]);

        if(!set.usesExertion) 
          (controls["rir"] as FormControl).disable() 
      }
      
      if (this.settings.rpeSystem == RpeSystem.Rpe) {
        let val = set.rpe ? set.rpe : 10 - set.rir;
        controls["rpe"] = new FormControl(val.toString(), [Validators.min(0), Validators.max(10)]);
        
        if(!set.usesExertion) 
          (controls["rpe"] as FormControl).disable() 
      }
    }

    return controls;
  }

  getSets(formGroups: FormGroup[]): Set[] {

    const sets = [];
    var setFormGroups = formGroups;

    for (let i = 0; i < setFormGroups.length; i++) {

      const setFormGroup = setFormGroups[i];

      const set = this.getSet(setFormGroup);
      sets.push(set);
    }

    return sets;
  }

  getSet(group: FormGroup): Set {

    const controls = group.controls;

    let set = new Set();
    set.exerciseId = this.exerciseId;
    set.id = controls["id"].value;

    // todo.. add weight attribute to application user
    // todo.. calculate weight from percentage and one rep max
    if (this.exerciseType.requiresBodyweight)
      set.weight = controls["weight"].value || 0;

    if (this.exerciseType.requiresReps)
      set.reps = controls["reps"].value || 0;

    if (this.exerciseType.requiresTime)
      set.time = controls["time"].value || 0;

    //handle weight transformations.. everything is system is in metric
    if (this.exerciseType.requiresWeight && !this.exerciseType.requiresBodyweight) {
      if (!this.settings.usePercentages && !controls['percentage']) {
        set.weight = transformWeightToNumber(controls["weight"].value, this.settings.unitSystem) || 0;
      } else {
        // get weight from percentage and 1 rep max
        let percentage = controls["percentage"].value;
        let calculatedWeight = percentage / 100 * this.userMaxControl.value;

        // don't need to convert unit systems because MAX will come in KGs from system
        set.percentage = percentage;
        set.maxUsedForPercentage = this.userMaxControl.value;
        set.weight = calculatedWeight;
      }
    }

    if (this.settings.useRpeSystem) {
      if (this.settings.rpeSystem == RpeSystem.Rpe) {
        set.rpe = controls["rpe"]?.value;
        set.usesExertion = controls["rpe"]?.disabled == false;
      }
      if (this.settings.rpeSystem == RpeSystem.Rir) {
        set.rir = controls["rir"].value;
        set.usesExertion = controls["rir"]?.disabled == false;
      }
    }
    
    return set;
  }

  onSubmit() {
    // are all forms valid
    if (!this.isFormValid) return;

    let sets = this.getSets(this.setFormGroups);

    this.onSubmitUpdateSets(sets, this.exerciseId);
  }

  onSubmitUpdateSets(sets: Set[], exerciseId) {

    var request = new UpdateManySetsRequest();
    request.sets = sets;
    request.exerciseId = exerciseId;

    this.setService.updateMany<UpdateManySetsRequest>(request)
      .pipe(
        switchMap(
          () => this.store.select(selectedTraining).pipe(map((training: Training) => ({sets, training})))
          // (sets, training) => ({ sets, training })
        ),
        take(1))
      .subscribe(
        (response: { sets: Set[], training: Training }) => {

          var index = response.training.exercises.findIndex(x => x.id == exerciseId);
          var exercises: Exercise[] = _.cloneDeep(response.training.exercises);
          exercises[index].sets = response.sets;

          var updatedTraining: Update<Training> = {
            id: response.training.id,
            changes: {
              exercises: exercises
            }
          };

          this.store.dispatch(trainingUpdated({ entity: updatedTraining }));
          this.onClose(response.sets);
        },
        err => console.log(err)
      )
  }

  get unitSystemUnitofMeasurement() {
    if (this.settings.unitSystem == UnitSystem.Metric)
      return UnitSystemUnitOfMeasurement.Metric;

    return UnitSystemUnitOfMeasurement.Imperial;
  }

  get isFormValid() {
    let valid = false;

    if (this.setFormGroups.length > 0) {
      valid = this.setFormGroups.reduce((prev, curr) => prev && curr.valid, true);
    }

    // uses percentages
    if (this.userMaxControl) {
      valid = valid && this.userMaxControl.valid;
    }

    return valid;
  }

  get weightUpperLimit() {
    let upperLimit = 600;

    if (this.settings.unitSystem == UnitSystem.Imperial) {
      upperLimit = 1200;
    }

    return upperLimit;
  }

  onClose(sets?: Set[]) {
    this.dialogRef.close(sets);
  }

  setControlsState(active: boolean) {
    if (active) {
      this.setFormGroups.forEach(x => x.enable());
    } else {
      this.setFormGroups.forEach(x => x.disable());
    }
  }

}
