import { exercises } from './exercise.selectors';
import { Update } from '@ngrx/entity';
import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { PersonalBest } from '../../server-models/entities/personal-best.model';
import { Exercise } from './../../server-models/entities/exercise.model';
import * as ExerciseActions from './exercise.actions';
import { exerciseInitialState, ExerciseState } from './exercise.state';
import * as _ from 'lodash-es';


export const exerciseReducer: ActionReducer<ExerciseState, Action> = createReducer(
  exerciseInitialState,


  // CREATE
  on(ExerciseActions.exerciseCreated, (state: ExerciseState, payload: { trainingId: string, entity: Exercise }) => {

    let exercises = _.cloneDeep(state.exercises);
    let trainingExercises = exercises[payload.trainingId];

    // new
    trainingExercises[payload.entity.id] = payload.entity;

    // write
    exercises[payload.trainingId] = trainingExercises;

    console.log(trainingExercises);
    console.log(exercises);

    return {
      ...state,
      exercises: exercises
    }
  }),

  // UPDATE
  on(ExerciseActions.exerciseUpdated, (state: ExerciseState, payload: { trainingId: string, entity: Update<Exercise> }) => {

    let exercises = _.cloneDeep(state.exercises);
    let trainingExercises = exercises[payload.trainingId];

    // update existing
    const existing = trainingExercises[payload.entity.id];
    trainingExercises[payload.entity.id] = Object.assign(existing, payload.entity.changes);

    exercises[payload.trainingId] = trainingExercises;

    return {
      ...state,
      exercises: exercises
    }
  }),

  // DELETE
  on(ExerciseActions.exerciseDeleted, (state: ExerciseState, payload: { trainingId: string, id: string }) => {

    let exercises = _.cloneDeep(state.exercises);
    let trainingExercises = exercises[payload.trainingId];

    // remove
    delete trainingExercises[payload.id];

    exercises[payload.trainingId] = trainingExercises;

    return {
      ...state,
      exercises: exercises
    }
  }),

  // GET ALL
  on(ExerciseActions.exerciseFetched, (state: ExerciseState, payload: { trainingId: string, entities: Exercise[] }) => {

    let exercises = _.cloneDeep(state.exercises);

    let entitiesDict: Record<string, Exercise> = {};
    payload.entities.forEach(entity => entitiesDict[entity.id] = entity);

    exercises[payload.trainingId] = entitiesDict;

    return {
      ...state,
      exercises: exercises
    }
  }),

  // SET SELECTED
  on(ExerciseActions.setSelectedExercise, (state: ExerciseState, payload: { entity: Exercise }) => {

    return Object.assign({}, state, { selectedExerciseId: payload.entity?.id ?? null })
  }),

  on(ExerciseActions.exercisePrsFetched, (state: ExerciseState, payload: { exerciseId: string, prs: PersonalBest[] }) => {

    let exercisePrs = { ...state.exercisePrs };
    exercisePrs[payload.exerciseId] = payload.prs;

    return {
      ...state,
      exercisePrs
    }
  }),

  // REORDER
  on(ExerciseActions.reorderExercises, (state: ExerciseState, payload: { trainingId: string, previousItem: string, currentItem: string }) => {

    // pluck types
    let allExercises = _.cloneDeep(state.exercises);
    let exercises = allExercises[payload.trainingId];

    const first = { ...exercises[payload.currentItem] };
    const second = { ...exercises[payload.previousItem] };

    // switch
    let firstOrder = first.order;
    let secondOrder = second.order;
    first.order = secondOrder;
    second.order = firstOrder;

    // map
    exercises[first.id] = first;
    exercises[second.id] = second;

    allExercises[payload.trainingId] = exercises;

    // update
    // return adapterExercise.setAll(exercisesModified, state);
    return {
      ...state,
      exercises: allExercises
    }
  }),
);

export const getSelectedExerciseId = (state: ExerciseState) => state.selectedExerciseId;

