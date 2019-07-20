import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { MediaType } from '../enums/media-type.enum';

export interface MediaFile {
    id: string;
    filename: string;
    ftpFilePath: string;
    downloadUrl: string;
    type: MediaType;
    dateUploaded: Date;
    dateModified: Date;
    user?: ApplicationUser;
    userId: string;
}

