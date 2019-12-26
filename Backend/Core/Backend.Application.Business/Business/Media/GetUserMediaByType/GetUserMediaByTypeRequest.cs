using Backend.Domain.Entities.Media;
using MediatR;
using System;
using System.Collections.Generic;
using MediaType = Backend.Domain.Enum.MediaType;

namespace Backend.Application.Business.Business.Media.GetUserMediaByType
{
    public class GetUserMediaByTypeRequest : IRequest<IEnumerable<MediaFile>>
    {
        public Guid UserId { get; set; }
        public MediaType MediaType { get; set; }
    }
}