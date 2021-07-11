using Backend.Common;
using Backend.Common.Extensions;
using Backend.Domain;
using Backend.Domain.Entities.Exercises;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Exercises.ExerciseTypeRequests.GetPaged
{
    public class GetPagedExerciseTypeRequestHandler : IRequestHandler<GetPagedExerciseTypeRequest, PagedList<ExerciseType>>
    {
        private readonly IApplicationDbContext _context;

        public GetPagedExerciseTypeRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<ExerciseType>> Handle(GetPagedExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var paginationModel = request.PaginationModel;

                var userId = request.UserId;

                var user = await _context.Athletes.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
                if (user?.CoachId != null)
                    userId = user.CoachId.Value;

                // get all items
                var exerciseTypes = _context.ExerciseTypes
                    .Include(x => x.Properties)
                    .ThenInclude(x => x.Tag)
                    .ThenInclude(x => x.TagGroup)
                    .Where(x => x.ApplicationUserId == userId);

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

                var allItems = await exerciseTypes.AsNoTracking().ToListAsync(cancellationToken);

                // if we are looking for page where specific item is
                if (request.PaginationModel.ItemId != Guid.Empty)
                {
                    var itemIdx = allItems.FindIndex(x => x.Id == request.PaginationModel.ItemId);
                    paginationModel.Page = (int)Math.Floor((double)itemIdx / request.PaginationModel.PageSize);
                }

                // page --- or fetch all results
                var exerciseTypesPagedList = !request.PaginationModel.FetchAll ? allItems.Skip(paginationModel.Page * paginationModel.PageSize).Take(paginationModel.PageSize).ToList() : allItems;

                //TODO: Technical debt.. this needs to be done better
                foreach (var exerciseType in exerciseTypesPagedList)
                {
                    exerciseType.Properties = exerciseType.Properties.Where(x => x.Show).ToList();
                }

                return new PagedList<ExerciseType>(exerciseTypesPagedList, totalItems);
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(ExerciseType), $"Could not find exercise type for {request.UserId} USER", e);
            }
        }
    }
}