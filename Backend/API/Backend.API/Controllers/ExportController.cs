﻿using Backend.Application.Business.Business.Export.Training;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class ExportController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> ExportTraining(ExportTrainingDataRequest request)
        {
            var result = await Mediator.Send(request);

            return File(result.Stream, result.ContentType, result.Title);
        }
    }
}