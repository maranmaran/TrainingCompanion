﻿using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace Backend.Business.Import.ImportTraining
{
    public class ImportTrainingRequest : IRequest
    {
        public Guid Userid { get; set; }
        public IFormFile File { get; set; }
    }
}