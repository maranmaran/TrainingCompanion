import { MediaFile } from 'src/server-models/entities/media-file.model';

export interface MediaState {
    videos: MediaFile[];
    images: MediaFile[];
    files: MediaFile[];
}

export const initialMediaState: MediaState = {
    videos: undefined,
    images: undefined,
    files: undefined,
};
