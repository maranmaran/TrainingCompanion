import { Validators } from '@angular/forms';
import { MediaFile } from 'src/server-models/entities/media-file.model';
import { createReducer, on } from '@ngrx/store';
import { Action, ActionReducer } from '@ngrx/store/src/models';
import { initialMediaState, MediaState } from './media.state';
import * as MediaActions from './media.actions';
import { MediaType } from 'src/server-models/enums/media-type.enum';

export const mediaReducer: ActionReducer<MediaState, Action> = createReducer(
    initialMediaState,

    on(MediaActions.mediaUploaded, (state: MediaState, mediaAction: { media: MediaFile }) => {
        switch (mediaAction.media.type) {
            case MediaType.Image:
                return {
                    ...state,
                    images: [...state.images, mediaAction.media]
                }
            case MediaType.Video:
                return {
                    ...state,
                    videos: [...state.videos, mediaAction.media]
                }
            case MediaType.File:
                return {
                    ...state,
                    files: [...state.files, mediaAction.media]
                }
            default: {
                return state;
            }
        };
    }),

    on(MediaActions.mediaFetched, (state: MediaState, mediaAction: { payload: { media: MediaFile[], type: MediaType } }) => {
        switch (mediaAction.payload.type) {
            case MediaType.Image:
                return {
                    ...state,
                    images: [...mediaAction.payload.media]
                }
            case MediaType.Video:
                return {
                    ...state,
                    videos: [...mediaAction.payload.media]
                }
            case MediaType.File:
                return {
                    ...state,
                    files: [...mediaAction.payload.media]
                }
            default: {
                return state;
            }
        };
    })

);

