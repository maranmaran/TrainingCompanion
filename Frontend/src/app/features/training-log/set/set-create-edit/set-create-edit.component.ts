import { Component, Inject, OnInit } from "@angular/core";
import {
  AbstractControl,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { MatSlideToggleChange } from "@angular/material/slide-toggle";
import { Update } from "@ngrx/entity";
import { Store } from "@ngrx/store";
import { Guid } from "guid-typescript";
import { noop, of } from "rxjs";
import { map, switchMap, take, tap } from "rxjs/operators";
import { SetService } from "src/business/services/feature-services/set.service";
import { transformWeightToNumber } from "src/business/services/shared/unit-system.service";
import { getUniqueArr, isEmpty } from "src/business/utils/utils";
import { userSetting } from "src/ngrx/auth/auth.selectors";
import { selectedExercise } from "src/ngrx/exercise/exercise.selectors";
import { AppState } from "src/ngrx/global-setup.ngrx";
import { selectedTraining } from "src/ngrx/training-log/training.selectors";
import { ExerciseType } from "src/server-models/entities/exercise-type.model";
import { Training } from "src/server-models/entities/training.model";
import { UserSetting } from "src/server-models/entities/user-settings.model";
import { RpeSystem } from "src/server-models/enums/rpe-system.enum";
import { UnitSystem } from "src/server-models/enums/unit-system.enum";
import { UIService } from "./../../../../../business/services/shared/ui.service";
import { exerciseUpdated } from "./../../../../../ngrx/exercise/exercise.actions";
import { UpdateManySetsRequest } from "./../../../../../server-models/cqrs/set/update-many-sets.request";
import { Exercise } from "./../../../../../server-models/entities/exercise.model";
import { PersonalBest } from "./../../../../../server-models/entities/personal-best.model";
import { Set } from "./../../../../../server-models/entities/set.model";
import { UnitSystemUnitOfMeasurement } from "./../../../../../server-models/enums/unit-system.enum";
import { ChooseMaxDialogComponent } from "./choose-max-dialog/choose-max-dialog.component";

@Component({
  selector: "app-set-create-edit",
  templateUrl: "./set-create-edit.component.html",
  styleUrls: ["./set-create-edit.component.scss"],
})
export class SetCreateEditComponent implements OnInit {
  constructor(
    private store: Store<AppState>,
    private setService: SetService,
    private dialogRef: MatDialogRef<SetCreateEditComponent>,
    private UIService: UIService,
    @Inject(MAT_DIALOG_DATA)
    public data: { action; title: string; sets: Set[]; prs: PersonalBest[] }
  ) {}

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
    this.store
      .select(userSetting)
      .pipe(take(1))
      .subscribe(
        (settings) =>
          (this.settings = Object.assign(new UserSetting(), settings))
      );
    this.store
      .select(selectedExercise)
      .pipe(take(1))
      .subscribe((exercise) => {
        this.exerciseId = exercise.id;
        this.exerciseType = exercise.exerciseType;
      });

    setTimeout((_) => {
      if (this.settings.usePercentages) this.setUserMax().subscribe(noop);

      this.createForms();
    });
  }

  createForms() {
    this.sets.forEach((set) => {
      this.setFormGroups.push(new FormGroup(this.getControls(set)));
    });
  }

  isRpeControlChecked(index) {
    if (!this.settings.useRpeSystem) return false;

    if (!isEmpty(this.sets) && !this.sets[index].usesExertion) return false;

    return (
      this.setFormGroups[index].controls["rpe"] ||
      this.setFormGroups[index].controls["rir"]
    );
  }

  isPercentageControlChecked(index) {
    if (!this.settings.usePercentages) return false;

    if (!isEmpty(this.sets) && !this.sets[index].usesPercentage) return false;

    return this.setFormGroups[index].controls["percentage"];
  }

  onSetRpeControl(event: MatSlideToggleChange, index: number) {
    if (!this.settings.useRpeSystem) {
      return false;
    }

    if (!event.checked) {
      this.setFormGroups[index].controls["rir"]?.disable();
      this.setFormGroups[index].controls["rpe"]?.disable();
    } else {
      if (this.settings.rpeSystem == RpeSystem.Rpe) {
        this.setFormGroups[index].addControl(
          "rpe",
          new FormControl("5", [Validators.min(0), Validators.max(100)])
        );
      } else {
        this.setFormGroups[index].addControl(
          "rir",
          new FormControl("5", [Validators.min(0), Validators.max(100)])
        );
      }

      this.setFormGroups[index].disable();
    }

    this.sets[index].usesExertion = event.checked;
  }

  onUsePercentage(event: MatSlideToggleChange, index: number) {
    if (!this.settings.usePercentages) {
      return false;
    }

    if (event.checked) {
      let setPercentageControl = (response) => {
        if (response) {
          this.setFormGroups[index].removeControl("weight");
          this.setFormGroups[index].addControl(
            "percentage",
            new FormControl(0, [
              Validators.required,
              Validators.min(0),
              Validators.max(100),
            ])
          );
          this.setFormGroups[index].disable();
        }
      };

      // check for one rep max...
      if (this.userMaxControl == null) {
        this.setUserMax().subscribe(setPercentageControl);
      } else {
        setPercentageControl(true);
      }
    } else {
      this.setFormGroups[index].addControl(
        "weight",
        new FormControl(0, [
          Validators.required,
          Validators.min(0),
          Validators.max(200),
        ])
      );
      this.setFormGroups[index].removeControl("percentage");
      this.setFormGroups[index].disable();

      if (!this.checkForPercentageControls()) {
        this.userMaxControl = null;
      }
    }

    this.sets[index].usesPercentage = event.checked;
  }

  checkForPercentageControls() {
    let result = false;
    this.setFormGroups.forEach((group) => {
      result = result || !!group.controls["percentage"];
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

    let maxArr = getUniqueArr(
      this.sets
        .filter((x) => x.maxUsedForPercentage && x.maxUsedForPercentage != 0)
        .map((x) => x.maxUsedForPercentage)
    );
    let usedMax = maxArr ? (maxArr[0] as number) : null;

    if (!userPR && !usedMax) {
      return this.onSetMaxDialog(systemPR);
    } else if (usedMax) {
      return of(this.setUserMaxControl(usedMax));
    } else if (userPR) {
      return of(this.setUserMaxControl(userPR.value));
    }
  }

  setUserMaxControl(value: number): FormControl {
    value = transformWeightToNumber(value, this.settings.unitSystem);
    let validators = [
      Validators.required,
      Validators.min(0),
      Validators.max(this.weightUpperLimit()),
    ];

    this.userMaxControl = new FormControl(value, validators);

    return this.userMaxControl;
  }

  onSetMaxDialog(systemPR: PersonalBest) {
    const dialogRef = this.UIService.openDialogFromComponent(
      ChooseMaxDialogComponent,
      {
        height: "auto",
        width: "98%",
        maxWidth: "20rem",
        autoFocus: false,
        disableClose: true,
        data: {
          title: "PERSONAL_BEST.SET_MAX",
          systemPR,
        },
        panelClass: ["choose-max-dialog-container", "dialog-container"],
      }
    );

    return dialogRef.afterClosed().pipe(
      take(1),
      tap((response) => {
        if (!response) {
          this.userMaxControl = null;
          this.settings.usePercentages = false;
        } else {
          this.setUserMaxControl(response.value);
        }
      })
    );
  }
  //#endregion

  getNewSet() {
    let set = new Set();
    set.exerciseId = this.exerciseId;
    set.usesPercentage = this.settings.usePercentages;
    set.usesExertion = this.settings.useRpeSystem;

    return set;
  }

  addGroup(set: Set = null) {
    set = set || this.getNewSet();

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
      controls["reps"] = new FormControl(set.reps, [
        Validators.required,
        Validators.min(0),
        Validators.max(100),
      ]);

    if (this.exerciseType.requiresTime)
      controls["time"] = new FormControl(set.time, [Validators.required]);

    // todo.. add weight attribute to application user
    if (this.exerciseType.requiresBodyweight)
      controls["weight"] = new FormControl(set.weight, [
        Validators.required,
        Validators.min(0),
        Validators.max(200),
      ]);

    // todo.. add weight attribute to application user
    if (
      this.exerciseType.requiresBodyweight ||
      this.exerciseType.requiresWeight
    ) {
      if (this.settings.usePercentages && set.usesPercentage) {
        // todo calculate percentage from 1 rep max and weight
        controls["percentage"] = new FormControl(set.percentage, [
          Validators.required,
          Validators.min(0),
          Validators.max(100),
        ]);
      } else {
        controls["weight"] = new FormControl(set.weight, [
          Validators.required,
          Validators.min(0),
          Validators.max(
            this.weightUpperLimit(this.exerciseType.requiresBodyweight)
          ),
        ]);
      }
    }

    if (this.settings.useRpeSystem) {
      if (this.settings.rpeSystem == RpeSystem.Rir) {
        let val = set.rir ? set.rir : 10 - set.rpe;
        controls["rir"] = new FormControl(val.toString(), [
          Validators.required,
          Validators.min(0),
          Validators.max(10),
        ]);

        if (!set.usesExertion) (controls["rir"] as FormControl).disable();
      }

      if (this.settings.rpeSystem == RpeSystem.Rpe) {
        let val = set.rpe ? set.rpe : 10 - set.rir;
        controls["rpe"] = new FormControl(val.toString(), [
          Validators.min(0),
          Validators.max(10),
        ]);

        if (!set.usesExertion) (controls["rpe"] as FormControl).disable();
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

    if (this.exerciseType.requiresReps) set.reps = controls["reps"].value || 0;

    if (this.exerciseType.requiresTime) set.time = controls["time"].value || 0;

    //handle weight transformations.. everything is system is in metric
    if (
      this.exerciseType.requiresWeight &&
      !this.exerciseType.requiresBodyweight
    ) {
      if (!this.settings.usePercentages || !controls["percentage"]) {
        set.weight =
          transformWeightToNumber(
            controls["weight"].value,
            this.settings.unitSystem
          ) || 0;
      } else {
        // get weight from percentage and 1 rep max
        let percentage = controls["percentage"].value;
        let calculatedWeight = (percentage / 100) * this.userMaxControl.value;

        // don't need to convert unit systems because MAX will come in KGs from system
        set.usesPercentage = true;
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

    this.setService
      .updateMany<UpdateManySetsRequest>(request)
      .pipe(
        switchMap(
          (sets: Set[]) =>
            this.store
              .select(selectedTraining)
              .pipe(map((training: Training) => ({ sets, training })))
          // (sets, training) => ({ sets, training })
        ),
        take(1)
      )
      .subscribe(
        (response: { sets: Set[]; training: Training }) => {
          var updatedExercise: Update<Exercise> = {
            id: exerciseId,
            changes: {
              sets: response.sets,
            },
          };

          console.log(updatedExercise);

          this.store.dispatch(
            exerciseUpdated({
              trainingId: response.training.id,
              entity: updatedExercise,
            })
          );

          this.onClose(response.sets);
        },
        (err) => console.log(err)
      );
  }

  get unitSystemUnitofMeasurement() {
    if (this.settings.unitSystem == UnitSystem.Metric)
      return UnitSystemUnitOfMeasurement.Metric;

    return UnitSystemUnitOfMeasurement.Imperial;
  }

  get isFormValid() {
    let valid = false;

    if (this.setFormGroups.length > 0) {
      valid = this.setFormGroups.reduce(
        (prev, curr) => prev && curr.valid,
        true
      );
    }

    // uses percentages
    if (this.userMaxControl) {
      valid = valid && this.userMaxControl.valid;
    }

    return valid;
  }

  weightUpperLimit(requiresBodyweight: boolean = false) {
    let upperLimit = !requiresBodyweight ? 600 : 300; // kgs in weights vs kgs in bodyweight

    if (this.settings.unitSystem == UnitSystem.Imperial) {
      upperLimit *= 2; // lbs
    }

    return upperLimit;
  }

  onClose(sets?: Set[]) {
    this.dialogRef.close(sets);
  }

  setControlsState(active: boolean) {
    if (active) {
      this.setFormGroups.forEach((group, index) => {
        group.enable();

        if (!isEmpty(this.sets) && !this.sets[index].usesExertion) {
          group.controls["rir"]?.disable();
          group.controls["rpe"]?.disable();
        }
      });
    } else {
      this.setFormGroups.forEach((x) => x.disable());
    }
  }
}
