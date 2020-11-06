using System;
using System.ComponentModel;
using Backend.Domain.Enum;

namespace Backend.Domain.Extensions
{
    public static class MediaExtensions
    {
        public static MediaType ConvertToMediaType(this MessageType type)
        {
            switch (type)
            {
                case MessageType.File:
                    return MediaType.File;
                case MessageType.Image:
                    return MediaType.Image;
                case MessageType.Video:
                    return MediaType.Video;
                default:
                    throw new InvalidEnumArgumentException(nameof(type), Convert.ToInt32(type), type.GetType());
            }
        }
    }
}