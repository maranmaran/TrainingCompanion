using System;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Business.Import.Requests.TrainingRequests.ImportTraining
{
    public class ImportTrainingRequest : IRequest
    {
        public Guid Userid { get; set; }
        public IFormFile File { get; set; }
    }
}