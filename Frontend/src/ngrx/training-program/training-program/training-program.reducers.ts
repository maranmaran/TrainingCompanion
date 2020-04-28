import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import * as _ from 'lodash';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { TrainingProgramUser } from './../../../server-models/entities/training-program.model';
import * as TrainingProgramActions from './training-program.actions';
import { adapterTrainingProgram, trainingProgramInitialState, TrainingProgramState } from './training-program.state';


export const trainingProgramReducer: ActionReducer<TrainingProgramState, Action> = createReducer(
    trainingProgramInitialState,


    // CREATE
    on(TrainingProgramActions.trainingProgramCreated, (state: TrainingProgramState, payload: { entity: TrainingProgram }) => {
        return adapterTrainingProgram.addOne(payload.entity, state);
    }),
    on(TrainingProgramActions.trainingProgramUserCreated, (state: TrainingProgramState, payload: { entity: TrainingProgramUser }) => {

      let trainingProgram =  _.cloneDeep(state.entities[payload.entity.trainingProgramId]);
      trainingProgram.users.push(payload.entity);

      var updateTrainingProgram: Update<TrainingProgram> = {
        id: trainingProgram.id,
        changes: trainingProgram
      };

      return adapterTrainingProgram.updateOne(updateTrainingProgram, state);
    }),

    // UPDATE
    on(TrainingProgramActions.trainingProgramUpdated, (state: TrainingProgramState, payload: { entity: Update<TrainingProgram> }) => {
        return adapterTrainingProgram.updateOne(payload.entity, state);
    }),

    // DELETE
    on(TrainingProgramActions.trainingProgramDeleted, (state: TrainingProgramState, payload: { id: string }) => {
        return adapterTrainingProgram.removeOne(payload.id, state);
    }),

    on(TrainingProgramActions.trainingProgramUserDeleted, (state: TrainingProgramState, payload: { entity: TrainingProgramUser }) => {

      let trainingProgram = _.cloneDeep(state.entities[payload.entity.trainingProgramId]) as TrainingProgram;
      let index = trainingProgram.users.findIndex(x => x.id == payload.entity.id);
      trainingProgram.users.splice(index, 1);

      var updateTrainingProgram: Update<TrainingProgram> = {
        id: trainingProgram.id,
        changes: trainingProgram
      };

      return adapterTrainingProgram.updateOne(updateTrainingProgram, state);
    }),

    // GET ALL
    on(TrainingProgramActions.trainingProgramFetched, (state: TrainingProgramState, payload: { entities: TrainingProgram[] }) => {
        return adapterTrainingProgram.addMany(payload.entities, state);
    }),

    // SET SELECTED
    on(TrainingProgramActions.setSelectedTrainingProgram, (state: TrainingProgramState, payload: { entity: TrainingProgram }) => {
        return {
            ...state,
            selectedTrainingProgramId: payload.entity ? payload.entity.id : null,
        };
    }),

);

export const getSelectedTrainingProgramId = (state: TrainingProgramState) => state.selectedTrainingProgramId;

// get the selectors
export const {
    selectIds,
    selectEntities,
    selectAll,
    selectTotal,
} = adapterTrainingProgram.getSelectors();
