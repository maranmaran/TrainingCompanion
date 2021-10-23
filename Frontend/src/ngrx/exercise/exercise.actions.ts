import { Update } from "@ngrx/entity";
import { createAction, props } from "@ngrx/store";
import { PersonalBest } from "../../server-models/entities/personal-best.model";
import { Exercise } from "./../../server-models/entities/exercise.model";

export const exerciseCreated = createAction(
  "[Exercise] Created",
  props<{ trainingId: string; entity: Exercise }>()
);

export const exerciseFetched = createAction(
  "[Exercise] Fetched",
  props<{ trainingId: string; entities: Exercise[] }>()
);

export const exerciseUpdated = createAction(
  "[Exercise] Updated",
  props<{ trainingId: string; entity: Update<Exercise> }>()
);

export const exerciseDeleted = createAction(
  "[Exercise] Deleted",
  props<{ trainingId: string; id: string }>()
);

export const setSelectedExercise = createAction(
  "[Exercise] Set selected exercise",
  props<{ entity: Exercise }>()
);

export const reorderExercises = createAction(
  "[Training details] Reorder exercises",
  props<{ trainingId: string; previousItem: string; currentItem: string }>()
);

export const exercisePrsFetched = createAction(
  "[Exercise PRs] PRs fetched",
  props<{ exerciseId: string; prs: PersonalBest[] }>()
);
