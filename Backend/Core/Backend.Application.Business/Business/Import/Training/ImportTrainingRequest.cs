﻿using System;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Business.Business.Import.Training
{
    public class ImportTrainingRequest: IRequest
    {
        public Guid Userid { get; set; }
        public IFormFile File { get; set; }
    }
}
