import { MediaType } from './../../../../../server-models/enums/media-type.enum';
export enum MessageType
{
    Text = 1,
    File = 2,
    Image = 3,
    Video = 4,
}

export function ConvertMessageToMediaType(type: MessageType): MediaType {
  switch (type) {
    case 2:
      return MediaType.File;
    case 3:
      return MediaType.Image;
    case 4:
      return MediaType.Video;
    default:
      throw Error('Unsupported media type');
  }
}
