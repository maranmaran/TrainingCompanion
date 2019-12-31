import { Action, ActionReducer, createReducer } from '@ngrx/store';
import { ExportImportState, initExportImportState } from './export-import.state';

export const exportImportReducers: ActionReducer<ExportImportState, Action> = createReducer(
  initExportImportState,
)
  // // CREATE
  // on(ExportImportActions.exerciseTypeCreated, (state: ExportImportState, payload: { entity: ExerciseType }) => {
  //     return adapterExerciseType.addOne(payload.entity, state);
  // }),

  // // UPDATE
  // on(ExportImportActions.exerciseTypeUpdated, (state: ExportImportState, payload: { entity: Update<ExerciseType> }) => {
  //     return adapterExerciseType.updateOne(payload.entity, state);
  // })
