import { Update } from "@ngrx/entity";
import { createAction, props } from "@ngrx/store";
import { TrainingProgram, TrainingProgramUser } from "src/server-models/entities/training-program.model";

export const trainingProgramCreated = createAction(
  "[TrainingProgram] Created",
  props<{ entity: TrainingProgram }>()
);

export const trainingProgramUserCreated = createAction(
  "[TrainingProgramUser] Created",
  props<{ entity: TrainingProgramUser }>()
);

export const trainingProgramFetched = createAction(
  "[TrainingProgram] Fetched",
  props<{ entities: TrainingProgram[] }>()
);

export const trainingProgramUpdated = createAction(
  "[TrainingProgram] Updated",
  props<{ entity: Update<TrainingProgram> }>()
);

export const trainingProgramDeleted = createAction(
  "[TrainingProgram] Deleted",
  props<{ id: string }>()
);

export const trainingProgramUserDeleted = createAction(
  "[TrainingProgramUser] Deleted",
  props<{ entity: TrainingProgramUser }>()
);

export const setSelectedTrainingProgram = createAction(
  "[TrainingProgram] Set selected trainingProgram",
  props<{ entity: TrainingProgram }>()
);

