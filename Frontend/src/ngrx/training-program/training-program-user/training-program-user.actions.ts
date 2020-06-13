import { createAction, props } from "@ngrx/store";
import { TrainingProgramUser } from "src/server-models/entities/training-program.model";

export const trainingProgramUserCreated = createAction(
  "[TrainingProgramUser] Created",
  props<{ entity: TrainingProgramUser }>()
);

export const trainingProgramUsersFetched = createAction(
  "[TrainingProgramUser] Fetched",
  props<{ entities: TrainingProgramUser[] }>()
);

export const trainingProgramUserDeleted = createAction(
  "[TrainingProgramUser] Deleted",
  props<{ id: string }>()
);
