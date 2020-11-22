import { TrainingDetailsResponse } from './../../server-models/cqrs/training/training-details.response';
import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { Training } from 'src/server-models/entities/training.model';

import * as TrainingActions from './training.actions';
import { adapterTraining, trainingInitialState, TrainingState } from './training.state';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { GetTrainingMetricsResponse } from 'src/server-models/cqrs/report/get-training-metrics.response';

export const trainingReducer: ActionReducer<TrainingState, Action> = createReducer(
  trainingInitialState,

  // CREATE
  on(TrainingActions.trainingCreated, (state: TrainingState, payload: { entity: Training }) => {
    return adapterTraining.addOne(payload.entity, state);
  }),

  // UPDATE
  on(TrainingActions.trainingUpdated, (state: TrainingState, payload: { entity: Update<Training> }) => {
    return adapterTraining.updateOne(payload.entity, state);
  }),

  // UPDATE MANY
  on(TrainingActions.manyTrainingsUpdated, (state: TrainingState, payload: { entities: Update<Training>[] }) => {
    return adapterTraining.updateMany(payload.entities, state);
  }),

  // DELETE
  on(TrainingActions.trainingDeleted, (state: TrainingState, payload: { id: string }) => {
    return adapterTraining.removeOne(payload.id, state);
  }),

  // GET ALL
  on(TrainingActions.trainingsFetched, (state: TrainingState, payload: { entities: Training[] }) => {
    return adapterTraining.addMany(payload.entities, state);
  }),

  // GET ALL - but replace state
  on(TrainingActions.trainingsFetchedReplaceState, (state: TrainingState, payload: { entities: Training[] }) => {
    return adapterTraining.setAll(payload.entities, state);
  }),

  // SET SELECTED
  on(TrainingActions.setSelectedTraining, (state: TrainingState, payload: { id: string }) => {
    return {
      ...state,
      selectedTrainingId: payload?.id,
    };
  }),

  on(TrainingActions.clearTrainingState, (state: TrainingState) => {
    return undefined;
  }),

  on(TrainingActions.setTrainingMedia, (state: TrainingState, payload: { id: string, media: MediaFile[] }) => {
    
    const mediaDict = { ...state.media };
    mediaDict[payload.id] = payload.media;

    return {
      ...state,
      media: mediaDict
    };
  }),

  on(TrainingActions.setTrainingMetrics, (state: TrainingState, payload: { id: string, metrics: GetTrainingMetricsResponse }) => {
    
    const metricsDict = { ...state.metrics };
    metricsDict[payload.id] = payload.metrics;

    return {
      ...state,
      metrics: metricsDict
    };
  }),

);

export const getSelectedTrainingId = (state: TrainingState) => state?.selectedTrainingId;

// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterTraining.getSelectors();
