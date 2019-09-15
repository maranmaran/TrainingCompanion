import { schema, normalize } from 'normalizr';
import { Training } from 'src/server-models/entities/training.model';
import { Dictionary } from '@ngrx/entity';
import { Exercise } from 'src/server-models/entities/exercise.model';
import { Set } from 'src/server-models/entities/set.model';
import { ExtensionActionTypes } from '@ngrx/store-devtools/src/extension';

const set = new schema.Entity('sets');

const exercise = new schema.Entity('exercises', {
    sets: [set]
});

const training = new schema.Entity('trainings', {
    exercises: [exercise]
});

export const trainingsSchema = [training];

export function normalizeTrainingArray(trainings: Training[]) {
    var normalized = normalize(trainings, trainingsSchema);

    var entities = {
        trainings: {},
        exercises: {},
        sets: {}
    }
    entities.trainings = normalized.entities.trainings ? normalized.entities.trainings : {};
    entities.exercises = normalized.entities.exercises ? normalized.entities.exercises : {};
    entities.sets = normalized.entities.sets ? normalized.entities.sets : {};

    var ids = {
        trainingIds: [],
        exerciseIds: [],
        setIds: []
    }
    ids.trainingIds = normalized.entities.trainings ? Object.values(normalized.entities.trainings).map(x => x.id) : [];
    ids.exerciseIds = normalized.entities.exercises ? Object.values(normalized.entities.exercises).map(x => x.id) : [];
    ids.setIds = normalized.entities.sets ? Object.values(normalized.entities.sets).map(x => x.id) : [];

    return {
        entities,
        ids
    }
}