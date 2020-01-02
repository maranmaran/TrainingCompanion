using Backend.Common;
using Backend.Common.Extensions;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.ExerciseType.Get
{
    public class GetExerciseTypeRequestHandler : IRequestHandler<GetExerciseTypeRequest, PagedList<Domain.Entities.ExerciseType.ExerciseType>>
    {
        private readonly IApplicationDbContext _context;

        public GetExerciseTypeRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Domain.Entities.ExerciseType.ExerciseType>> Handle(GetExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var paginationModel = request.PaginationModel;

                // get all items
                var exerciseTypes = _context.ExerciseTypes
                    .Include(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)
                    .Where(x => x.ApplicationUserId == request.UserId);

                // filter
                if (!string.IsNullOrWhiteSpace(paginationModel.FilterQuery))
                    exerciseTypes = exerciseTypes.Where(x =>
                        x.Name.ToLower().Contains(paginationModel.FilterQuery.ToLower()) || x.Code.ToLower().Contains(paginationModel.FilterQuery.ToLower()));

                // get count of items
                var totalItems = exerciseTypes.Count();

                // sort
                if (!string.IsNullOrWhiteSpace(paginationModel.SortBy))
                {
                    exerciseTypes = (paginationModel.SortBy switch
                    {
                        "name" => exerciseTypes.Sort(type => type.Name, paginationModel.SortDirection),
                        "code" => exerciseTypes.Sort(type => type.Name, paginationModel.SortDirection),
                        _ => throw new Exception($"Can't filter by {paginationModel.SortBy}")
                    });
                }

                // page
                var exerciseTypesPagedList = exerciseTypes.Skip(paginationModel.Page * paginationModel.PageSize).Take(paginationModel.PageSize);

                //TODO: Technical debt.. this needs to be done better
                foreach (var exerciseType in exerciseTypesPagedList)
                {
                    exerciseType.Properties = exerciseType.Properties.Where(x => x.Show).ToList();
                }

                var list = await exerciseTypesPagedList.ToListAsync(cancellationToken);
                return new PagedList<Domain.Entities.ExerciseType.ExerciseType>(list, totalItems);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Domain.Entities.ExerciseType.ExerciseType), $"Could not find exercise type for {request.UserId} USER", e);
            }
        }


    }
}