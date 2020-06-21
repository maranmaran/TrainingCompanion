import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

export class UpdatePersonalBestRequest {

  constructor(data: Partial<UpdatePersonalBestRequest>) {
    Object.assign(this, data);
  }

  id: string;
  reps?: number;
  value?: number;
  dateAchieved: Date;
  exerciseTypeId: string;
  unitSystem: UnitSystem;
  bodyweight: number;
}
