import { Update } from '@ngrx/entity';
import { createAction, props } from "@ngrx/store";
import { ExerciseType } from 'src/server-models/entities/exercise-type.model';
import { PagingModel } from './../../app/shared/material-table/table-models/paging.model';


export const exerciseTypeCreated = createAction(
  '[ExerciseType] Created',
  props<{ entity: ExerciseType }>()
);

export const exerciseTypesFetched = createAction(
  '[ExerciseType] Fetched',
  props<{ entities: ExerciseType[], totalItems: number, pagingModel: PagingModel }>()
);

export const allExerciseTypesFetched = createAction(
  '[ExerciseType] All fetched',
  props<{ entities: ExerciseType[]}>()
);

export const exerciseTypeUpdated = createAction(
  '[ExerciseType] Updated',
  props<{ entity: Update<ExerciseType> }>()
);

export const manyExerciseTypesUpdated = createAction(
  '[ExerciseType] Many updated',
  props<{ entities: Update<ExerciseType>[] }>()
);

export const exerciseTypeDeleted = createAction(
  '[ExerciseType] Deleted',
  props<{ id: string }>()
);
export const exerciseDeleted = createAction(
  '[ExerciseType] Deleted',
  props<{ id: string }>()
);

export const setSelectedExerciseType = createAction(
  '[ExerciseType] Set selected exerciseType',
  props<{ entity: ExerciseType }>()
);

export const clearExerciseTypeState = createAction(
'[ExerciseType] Clear',
);
