using System;
using System.Collections.Generic;
using Backend.Domain.Entities.Media;
using MediatR;
using MediaType = Backend.Domain.Enum.MediaType;

namespace Backend.Business.Media.MediaRequests.GetUserMediaByType
{
    public class GetUserMediaByTypeRequest : IRequest<IEnumerable<MediaFile>>
    {
        public Guid UserId { get; set; }
        public MediaType MediaType { get; set; }
    }
}