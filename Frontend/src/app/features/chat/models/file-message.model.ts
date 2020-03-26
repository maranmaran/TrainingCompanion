import { MessageType } from './enums/message-type.enum';
import { Message } from './message.model';

export class FileMessage extends Message
{
    constructor() {
        super();

        this.type = MessageType.File;
    }

    public downloadUrl: string;
    public mimeType: string;
    public fileSizeInBytes: number = 0;
}
