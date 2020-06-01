import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { PersonalBest } from 'src/server-models/entities/personal-best.model';
import { Training } from 'src/server-models/entities/training.model';
import * as TrainingActions from './training.actions';
import { adapterTraining, trainingInitialState, TrainingState } from './training.state';

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
    return adapterTraining.addAll(payload.entities, state);
  }),

  // SET SELECTED
  on(TrainingActions.setSelectedTraining, (state: TrainingState, payload: { entity: Training }) => {
    return {
      ...state,
      selectedTrainingId: payload.entity ? payload.entity.id : null,
    };
  }),
  on(TrainingActions.setSelectedExercise, (state: TrainingState, payload: { entity: Exercise }) => {
    return {
      ...state,
      selectedExerciseId: payload.entity ? payload.entity.id : null,
    };
  }),

  on(TrainingActions.clearTrainingState, (state: TrainingState) => {
    return undefined;
  }),

  on(TrainingActions.exercisePrsFetched, (state: TrainingState, payload: { prs: PersonalBest[] }) => {
    return {
      ...state,
      exercisePrs: [...payload.prs]
    };
  }),

  // REORDER
  on(TrainingActions.reorderExercises, (state: TrainingState, payload: { trainingId:string, previousItem: string, currentItem: string }) => {

    // pluck types
    var training = state.entities[payload.trainingId];
    const first = {...training.exercises.find(x => x.id == payload.currentItem)};
    const second = {...training.exercises.find(x => x.id == payload.previousItem)};

    // switch
    let firstOrder = first.order;
    let secondOrder = second.order;
    first.order = secondOrder;
    second.order = firstOrder;

    // map
    const exercises = training.exercises.map(x => {
      if(x.id == first.id) {
        return first;
      }

      if (x.id == second.id) {
        return second;
      }

      return x;
    })

    // update statements
    const update: Update<Training> = {
      id: payload.trainingId,
      changes: { exercises }
    }

    // update
    return adapterTraining.updateOne(update, state);
  }),
);

export const getSelectedTrainingId = (state: TrainingState) => state?.selectedTrainingId;
export const getSelectedExerciseId = (state: TrainingState) => state?.selectedExerciseId;

// get the selectors
export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapterTraining.getSelectors();
