import { MediaType } from './../../server-models/enums/media-type.enum';
import { MediaState } from './media.state';
import { createSelector, createFeatureSelector } from '@ngrx/store';

export const selectMediaState = createFeatureSelector<MediaState>("media");

export function getSelectorByMediaType(type: MediaType) {
    let selector;

    switch (type) {
        case MediaType.Image:
            selector = images;
            break;
        case MediaType.Video:
            selector = videos;
            break;
        case MediaType.File:
            selector = files;
            break;
        default:
            throw new Error('This media type is non existant: ' + type);
    }

    return selector;
}

export const images = createSelector(
    selectMediaState,
    (mediaState: MediaState) => mediaState.images
)

export const videos = createSelector(
    selectMediaState,
    (mediaState: MediaState) => mediaState.videos
)

export const files = createSelector(
    selectMediaState,
    (mediaState: MediaState) => mediaState.files
)