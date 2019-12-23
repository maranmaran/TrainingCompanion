using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.ExerciseType;
using Backend.Service.Excel.Interfaces;
using Backend.Service.Excel.Models.Import.ExerciseType;
using Backend.Service.Excel.Models.Import.Training;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;

namespace Backend.Application.Business.Business.Import.ExerciseType
{
    public class ImportExerciseTypeRequestHandler : IRequestHandler<ImportExerciseTypeRequest, Unit>
    {
        private readonly IExcelService _excelService;
        private readonly IApplicationDbContext _context;

        public ImportExerciseTypeRequestHandler(IExcelService excelService, IApplicationDbContext context)
        {
            _excelService = excelService;
            _context = context;
        }

        public async Task<Unit> Handle(ImportExerciseTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var dataRows = await _excelService.ParseImportData<ImportExerciseTypeDto>(request.File, cancellationToken);

                var exerciseTypes = await ConverImportDataToEntityRepresentation(dataRows, request.Userid, cancellationToken);

                _context.ExerciseTypes.UpdateRange(exerciseTypes);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception("Could not import exercises.", e);
            }
        }

        private async Task<IEnumerable<Domain.Entities.ExerciseType.ExerciseType>> ConverImportDataToEntityRepresentation(
            IEnumerable<ImportExerciseTypeDto> data, 
            Guid userId,
            CancellationToken cancellationToken)
        {
            var existingExerciseTypes = await _context
                .ExerciseTypes
                .Where(x => x.ApplicationUserId == userId)
                .AsNoTracking()
                .ToDictionaryAsync(x => x.Code, x => x, cancellationToken: cancellationToken);

            var existingTagGroups = await _context
                .TagGroups
                .Include(x => x.Tags)
                .Where(x => x.ApplicationUserId == userId)
                .AsNoTracking()
                .ToDictionaryAsync(x => x.Type, x => x, cancellationToken);

            var exerciseTypes = await Task.WhenAll(data.Select(async x =>
            {
                // parse all tags and tag groups
                var exerciseProperties = new List<ExerciseTypeTag>();
                if(!string.IsNullOrWhiteSpace(x.Tags) && !string.IsNullOrWhiteSpace(x.TagGroups)) 
                    exerciseProperties = (await ParseExerciseProperties(userId, x.TagGroups, x.Tags, existingTagGroups, cancellationToken)).ToList();

                existingExerciseTypes.TryGetValue(x.Code, out var existingType);
                var result = new Domain.Entities.ExerciseType.ExerciseType();

                if (existingType != null)
                    result = existingType;

                result.Active = x.Active;
                result.Name = x.Name;
                result.Code = x.Code;
                result.RequiresBodyweight = x.RequiresBodyweight;
                result.RequiresSets = x.RequiresSets;
                result.RequiresWeight = x.RequiresWeight;
                result.RequiresTime = x.RequiresTime;
                result.RequiresReps = x.RequiresReps;
                result.ApplicationUserId = userId;
                result.Properties = exerciseProperties;

                return result;
            }));

            return exerciseTypes;
        }

        private async Task<IEnumerable<ExerciseTypeTag>> ParseExerciseProperties(
            Guid userId, 
            string importGroups,
            string importTags, 
            IDictionary<string, Domain.Entities.ExerciseType.TagGroup> existingTagGroups,
            CancellationToken cancellationToken)
        {
                var importTagGroupsArr = importGroups.Split(",").Select(x => x.Trim()).ToArray();
                var importTagsArr = importTags.Split(",").Select(x => x.Trim()).ToArray();

                // parse to some kind of better collection that represents nesting
                var tagsDict = new Dictionary<string, List<string>>(); // group, tags
                for (var i = 0; i < importTagGroupsArr.Length; i++)
                {
                    if (!tagsDict.TryAdd(importTagGroupsArr[i], new List<string>() { importTagsArr[i] }))
                    {
                        tagsDict[importTagGroupsArr[i]].Add(importTagsArr[i]);
                    }
                }

                var resultTagGroups = new List<Domain.Entities.ExerciseType.TagGroup>();
                foreach (var (group, tags) in tagsDict)
                {
                    // if group exists
                    // check all given tags who exists and those who not - create new tag
                    // update existing group
                    if (existingTagGroups.TryGetValue(group, out var existingTagGroup))
                    {
                        var tagsToAdd = tags.Select(tag => existingTagGroup.Tags.FirstOrDefault(x => x.Value == tag) ?? new Domain.Entities.ExerciseType.Tag() {Value = tag}).ToList();

                        existingTagGroup.Tags = tagsToAdd;

                        resultTagGroups.Add(existingTagGroup);
                    }
                    // if group doesn't exist - create it and add all given tags
                    else
                    {
                        var newTagGroup = new Domain.Entities.ExerciseType.TagGroup
                        {
                            ApplicationUserId = userId,
                            Type = group,
                            Tags = tags.Select(x => new Domain.Entities.ExerciseType.Tag
                            {
                                Value = x,
                            }).ToList()
                        };

                        resultTagGroups.Add(newTagGroup);
                    }
                }

                // assign group to tags.. so when we add this collection to exercise type.. newly created groups will be created with EF
                var resultTags = resultTagGroups.SelectMany(x =>
                {
                    x.Tags.ToList().ForEach(y =>  y.TagGroup = x);
                    return x.Tags;
                });

                return resultTags.Select(x => new ExerciseTypeTag
                {
                    Tag = x,
                    TagId = x.Id,
                });
        }
    }
}