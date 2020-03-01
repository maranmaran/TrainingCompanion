﻿using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Threading.Tasks;
using Backend.Business.ExerciseType.ExerciseType.Create;
using Backend.Business.ExerciseType.ExerciseType.Delete;
using Backend.Business.ExerciseType.ExerciseType.Get;
using Backend.Business.ExerciseType.ExerciseType.GetAll;
using Backend.Business.ExerciseType.ExerciseType.Update;

namespace Backend.API.Controllers
{
    public class ExerciseTypeController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            return Ok(await Mediator.Send(new GetAllExerciseTypeRequest() { UserId = userId }));
        }

        [HttpPost]
        public async Task<IActionResult> GetPaged(GetPagedExerciseTypeRequest request)
        {
            return Ok(await Mediator.Send(request));
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseTypeRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateExerciseTypeRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteExerciseTypeRequest() { Id = id }));
        }
    }
}