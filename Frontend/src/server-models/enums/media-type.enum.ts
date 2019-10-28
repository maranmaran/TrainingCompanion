export enum MediaType {
    Video = 'Video',
    Image = 'Image',
    File = 'File'
}

export function getMediaType(file: File) {
  const type = file.type;

  if (type.includes('image')) {
    return MediaType.Image;
  }

  if (type.includes('video')) {
    return MediaType.Video;
  }
}
