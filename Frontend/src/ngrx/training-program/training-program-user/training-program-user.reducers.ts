import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { TrainingProgramUser } from 'src/server-models/entities/training-program.model';
import * as TrainingProgramUserActions from './training-program-user.actions';
import { adapterTrainingProgramUser, trainingProgramUserInitialState, TrainingProgramUserState } from './training-program-user.state';


export const trainingProgramUserReducer: ActionReducer<TrainingProgramUserState, Action> = createReducer(
  trainingProgramUserInitialState,

  // CREATE
  on(TrainingProgramUserActions.trainingProgramUserCreated, (state: TrainingProgramUserState, payload: { entity: TrainingProgramUser }) => {
    return adapterTrainingProgramUser.addOne(payload.entity, state);
  }),

  // DELETE
  on(TrainingProgramUserActions.trainingProgramUserDeleted, (state: TrainingProgramUserState, payload: { id: string }) => {
    return adapterTrainingProgramUser.removeOne(payload.id, state);
  }),

  // GET ALL
  on(TrainingProgramUserActions.trainingProgramUsersFetched, (state: TrainingProgramUserState, payload: { entities: TrainingProgramUser[] }) => {
    return adapterTrainingProgramUser.addMany(payload.entities, state);
  }),

);

export const getSelectedTrainingProgramUserId = (state: TrainingProgramUserState) => state.selectedTrainingProgramUserId;

// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterTrainingProgramUser.getSelectors();
