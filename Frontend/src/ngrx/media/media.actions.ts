import { MediaType } from './../../server-models/enums/media-type.enum';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { createAction, props } from '@ngrx/store';

export const mediaUploaded = createAction(
    '[Media API] Upload Media',
    props<{media: MediaFile}>()
)

export const mediaFetched = createAction(
    '[Media API] Media fetched',
    props<{payload: {media: MediaFile[], type: MediaType}}>()
)

