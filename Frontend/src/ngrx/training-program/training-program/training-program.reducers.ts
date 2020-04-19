
import * as TrainingProgramActions from './training-program.actions';
import { ActionReducer, createReducer, Action, on } from '@ngrx/store';
import { TrainingProgramState, trainingProgramInitialState, adapterTrainingProgram } from './training-program.state';
import { TrainingProgram } from 'src/server-models/entities/training-program.model';
import { Update } from '@ngrx/entity';

export const trainingProgramReducer: ActionReducer<TrainingProgramState, Action> = createReducer(
    trainingProgramInitialState,


    // CREATE
    on(TrainingProgramActions.trainingProgramCreated, (state: TrainingProgramState, payload: { entity: TrainingProgram }) => {
        return adapterTrainingProgram.addOne(payload.entity, state);
    }),

    // UPDATE
    on(TrainingProgramActions.trainingProgramUpdated, (state: TrainingProgramState, payload: { entity: Update<TrainingProgram> }) => {
        return adapterTrainingProgram.updateOne(payload.entity, state);
    }),

    // DELETE
    on(TrainingProgramActions.trainingProgramDeleted, (state: TrainingProgramState, payload: { id: string }) => {
        return adapterTrainingProgram.removeOne(payload.id, state);
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
