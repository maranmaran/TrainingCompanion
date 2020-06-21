import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

export class CreatePersonalBestRequest {

  constructor(data: Partial<CreatePersonalBestRequest>) {
    Object.assign(this, data);
  }

  reps?: number;
  value?: number;
  dateAchieved: Date;
  exerciseTypeId: string;
  unitSystem: UnitSystem;
  bodyweight: number;
}
