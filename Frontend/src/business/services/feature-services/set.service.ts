import { HttpClient } from '@angular/common/http';
import { Set } from '../../../server-models/entities/set.model';
import { CrudService } from '../crud.service';
import { Injectable } from "@angular/core";
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { RpeSystem } from 'src/server-models/enums/rpe-system.enum';

@Injectable()
export class SetService extends CrudService<Set> {

  constructor(
    private httpDI: HttpClient
  ) {
    super(httpDI, 'Set');
  }

  createForms(sets) {
    const groups = [];
    sets.forEach(set => {
      groups.push(
        new FormGroup(this.getControls(set))
      )
    });
  }

  
  getControls(set: Set): { [key: string]: AbstractControl } {
    const controls = {};

    controls["id"] = new FormControl(set.id);

    if (this.z.requiresReps)
      controls["reps"] = new FormControl(set.reps, [Validators.required, Validators.min(0), Validators.max(100)]);

    if (this.exerciseType.requiresTime)
      controls["time"] = new FormControl(set.time, [Validators.required]);

    // todo.. add weight attribute to application user
    if (this.exerciseType.requiresBodyweight)
      controls["weight"] = new FormControl(set.weight, [Validators.required, Validators.min(0), Validators.max(200)]);

    if (this.exerciseType.requiresWeight && !this.exerciseType.requiresBodyweight) {
      if (!this.settings.usePercentages || !set.usesPercentage) {
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

        if (!set.usesExertion)
          (controls["rir"] as FormControl).disable()
      }

      if (this.settings.rpeSystem == RpeSystem.Rpe) {
        let val = set.rpe ? set.rpe : 10 - set.rir;
        controls["rpe"] = new FormControl(val.toString(), [Validators.min(0), Validators.max(10)]);

        if (!set.usesExertion)
          (controls["rpe"] as FormControl).disable()
      }
    }

    return controls;
  }

}
