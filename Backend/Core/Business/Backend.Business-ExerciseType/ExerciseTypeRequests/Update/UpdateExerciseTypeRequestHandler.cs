﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Exercises.ExerciseTypeRequests.Update
{
    public class UpdateExerciseTypeRequestHandler :
        IRequestHandler<UpdateExerciseTypeRequest, ExerciseType>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateExerciseTypeRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExerciseType> Handle(UpdateExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var entityToUpdate = _context.ExerciseTypes.Include(x => x.Properties).First(x => x.Id == request.ExerciseType.Id);

                // delete property relations
                foreach (var prop in entityToUpdate.Properties)
                {
                    if (request.ExerciseType.Properties.All(x => x.Id != prop.Id))
                    {
                        _context.Entry(prop).State = EntityState.Deleted;
                    }
                }

                _mapper.Map(request.ExerciseType, entityToUpdate);

                _context.ExerciseTypes.Update(entityToUpdate);
                await _context.SaveChangesAsync(cancellationToken);

                return request.ExerciseType;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ExerciseType), e);
            }
        }
    }
}