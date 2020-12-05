import { Update } from "@ngrx/entity";
import { createAction, props } from "@ngrx/store";
import { TrainingBlockDay } from "src/server-models/entities/training-program.model";
import { Training } from 'src/server-models/entities/training.model';

export const trainingBlockDayCreated = createAction(
  "[TrainingBlockDay] Created",
  props<{ entity: TrainingBlockDay }>()
);

export const trainingBlockDayFetched = createAction(
  "[TrainingBlockDay] Fetched",
  props<{ entities: TrainingBlockDay[] }>()
);

export const trainingBlockDayUpdated = createAction(
  "[TrainingBlockDay] Updated",
  props<{ entity: Update<TrainingBlockDay> }>()
);

export const trainingBlockDayDeleted = createAction(
  "[TrainingBlockDay] Deleted",
  props<{ id: string }>()
);

export const setSelectedTrainingBlockDay = createAction(
  "[TrainingBlockDay] Set selected trainingBlockDay",
  props<{ entity: TrainingBlockDay }>()
);

export const addTraining = createAction(
  "[TrainingBlockDay] Add training",
  props<{ dayId: string, training: Training}>()
)

export const removeTraining = createAction(
  "[TrainingBlockDay] Remove training",
  props<{ dayId: string, trainingId: string}>()
)