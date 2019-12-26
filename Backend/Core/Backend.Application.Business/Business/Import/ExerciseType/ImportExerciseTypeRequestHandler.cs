using Backend.Domain;
using Backend.Domain.Entities.ExerciseType;
using Backend.Service.Excel.Interfaces;
using Backend.Service.Excel.Models.Import.ExerciseType;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

                //_context.ExerciseTypes.UpdateRange(exerciseTypes);

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
                existingExerciseTypes.TryGetValue(x.Code, out var existingType);
                var result = new Domain.Entities.ExerciseType.ExerciseType();

                if (existingType != null)
                {
                    result = existingType;
                    _context.Entry(result).State = EntityState.Modified;
                }
                else
                {
                    result.Id = Guid.NewGuid();
                    _context.Entry(result).State = EntityState.Added;
                }

                result.Active = x.Active;
                result.Name = x.Name;
                result.Code = x.Code;
                result.RequiresBodyweight = x.RequiresBodyweight;
                result.RequiresSets = x.RequiresSets;
                result.RequiresWeight = x.RequiresWeight;
                result.RequiresTime = x.RequiresTime;
                result.RequiresReps = x.RequiresReps;
                result.ApplicationUserId = userId;

                // parse all tags and tag groups
                if (!string.IsNullOrWhiteSpace(x.Tags) && !string.IsNullOrWhiteSpace(x.TagGroups))
                    result.Properties = (await ParseExerciseProperties(userId, x.TagGroups, x.Tags, result, existingTagGroups)).ToList();

                return result;
            }));

            return exerciseTypes;
        }

        private async Task<IEnumerable<ExerciseTypeTag>> ParseExerciseProperties(
            Guid userId,
            string importGroups,
            string importTags,
            Domain.Entities.ExerciseType.ExerciseType newType,
            IDictionary<string, Domain.Entities.ExerciseType.TagGroup> existingGroups)
        {
            var importTagGroupsArr = importGroups.Split(",").Select(x => x.Trim()).ToArray();
            var importTagsArr = importTags.Split(",").Select(x => x.Trim()).ToArray();

            // parse to some kind of better collection that represents nesting
            var tagsDict = GetTagsDictionary(importTagGroupsArr, importTagsArr); // group, tags

            var cacheTags = new Dictionary<string, Domain.Entities.ExerciseType.Tag>();
            var cacheGroups = new Dictionary<string, Domain.Entities.ExerciseType.TagGroup>();
            var resultGroups = new List<Domain.Entities.ExerciseType.TagGroup>();
            foreach (var (group, tags) in tagsDict)
            {
                // if group exists
                // check all given tags who exists and those who not - create new tag
                // update existing group
                if (existingGroups.TryGetValue(group, out var existingTagGroup))
                {
                    var tagsToAdd = tags.Select(tag =>
                    {
                        var tagToAdd = existingTagGroup.Tags.FirstOrDefault(x => x.Value == tag);
                        if (tagToAdd == null)
                        {
                            if (!cacheTags.TryGetValue(tag, out tagToAdd))
                            {
                                tagToAdd = new Domain.Entities.ExerciseType.Tag()
                                {
                                    Id = Guid.NewGuid(),
                                    Value = tag
                                };

                                cacheTags.Add(tagToAdd.Value, tagToAdd);
                            }

                            _context.Entry(tagToAdd).State = EntityState.Added;
                        }

                        return tagToAdd;
                    }).ToList();

                    existingTagGroup.Tags = tagsToAdd;

                    resultGroups.Add(existingTagGroup);
                    _context.Entry(existingTagGroup).State = EntityState.Modified;
                }
                // if group doesn't exist - create it and add all given tags
                else
                {
                    var newTags = tags.Select(x =>
                    {
                        var newTag = new Domain.Entities.ExerciseType.Tag
                        {
                            Id = Guid.NewGuid(),
                            Value = x,
                        };

                        _context.Entry(newTag).State = EntityState.Added;

                        return newTag;
                    }).ToList();

                    if (!cacheGroups.TryGetValue(group, out var newTagGroup))
                    {
                        newTagGroup = new Domain.Entities.ExerciseType.TagGroup
                        {
                            Id = Guid.NewGuid(),
                            ApplicationUserId = userId,
                            Type = group,
                        };

                        cacheGroups[newTagGroup.Type] = newTagGroup;
                        _context.Entry(newTagGroup).State = EntityState.Added;
                    }

                    newTagGroup.Tags = newTags;
                    resultGroups.Add(newTagGroup);
                }
            }

            // assign group to tags.. so when we add this collection to exercise type.. newly created groups will be created with EF
            var resultTags = resultGroups.SelectMany(x =>
            {
                x.Tags.ToList().ForEach(y => y.TagGroup = x);
                return x.Tags;
            });

            return resultTags.Select(x =>
            {
                var property = new ExerciseTypeTag
                {
                    Tag = x,
                    TagId = x.Id,
                    ExerciseTypeId = newType.Id,
                    ExerciseType = newType,
                    Show = true,
                };

                _context.Entry(property).State = EntityState.Added;

                return property;
            });
        }

        private Dictionary<string, List<string>> GetTagsDictionary(string[] groups, string[] tags)
        {
            var result = new Dictionary<string, List<string>>();

            for (var i = 0; i < groups.Length; i++)
            {
                var group = groups[i];
                var tag = tags[i];

                if (!result.TryAdd(group, new List<string>() { tag }))
                {
                    result[group].Add(tag);
                }
            }

            return result;
        }
    }
}