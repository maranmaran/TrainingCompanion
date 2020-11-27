import { MediaFile } from './../../entities/media-file.model';
export class TrainingDetailsResponse {
    programName: string;
    programDay: string;

    media: MediaFile[];
}