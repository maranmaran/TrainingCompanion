using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.ExerciseType;
using Backend.Service.Excel.Models.Import.ExerciseType;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Import.ExerciseType
{
    /// <summary>
    /// Imports exercise type data according to some specific rules and schema
    /// See available columns for importing in excel service
    /// </summary>
    public class ExerciseTypeImporter
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        private readonly Guid _userId;
        private readonly IDictionary<string, Domain.Entities.ExerciseType.TagGroup> _existingGroups;
        private readonly IDictionary<string, Domain.Entities.ExerciseType.ExerciseType> _existingTypes;

        public ExerciseTypeImporter(IApplicationDbContext context, Guid userId, IMapper mapper)
        {
            _context = context;
            _userId = userId;
            _mapper = mapper;

            _existingTypes = _context
                .ExerciseTypes
                .Where(x => x.ApplicationUserId == userId)
                .AsNoTracking()
                .ToDictionary(x => x.Code, x => x);

            _existingGroups = _context
                .TagGroups
                .Include(x => x.Tags)
                .Where(x => x.ApplicationUserId == userId)
                .AsNoTracking()
                .ToDictionary(x => x.Type, x => x);
        }

        public async Task DoImport(IEnumerable<ImportExerciseTypeDto> data, CancellationToken cancellationToken = default)
        {
            Parallel.ForEach(
                source: data,  // source data
                body: DoWork // unit of work
            );

            await _context.SaveChangesAsync(cancellationToken);
        }

        private void DoWork(ImportExerciseTypeDto row, ParallelLoopState loopState)
        {
            // parse and get exercise type from data row
            var type = ParseExerciseType(row);

            // parse all tags and tag groups and assign exercise properties (join table entity) on exercise type
            if (!string.IsNullOrWhiteSpace(row.Tags) && !string.IsNullOrWhiteSpace(row.TagGroups))
                type.Properties = ParseExerciseTypeProperties(row.TagGroups, row.Tags).ToList();
        }

        private Domain.Entities.ExerciseType.ExerciseType ParseExerciseType(ImportExerciseTypeDto row)
        {
            _existingTypes.TryGetValue(row.Code, out var existingType);

            var type = new Domain.Entities.ExerciseType.ExerciseType();
            if (existingType != null)
            {
                type = existingType;
                _context.Entry(type).State = EntityState.Modified;
            }
            else
            {
                type.Id = Guid.NewGuid();
                _context.Entry(type).State = EntityState.Added;
            }

            _mapper.Map<Domain.Entities.ExerciseType.ExerciseType>(row);
            type.ApplicationUserId = _userId;

            return type;
        }


        // TODO: REFACTOR
        private IEnumerable<ExerciseTypeTag> ParseExerciseTypeProperties(string importGroups, string importTags)
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
                if (_existingGroups.TryGetValue(group, out var existingTagGroup))
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
                            ApplicationUserId = _userId,
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
                    //ExerciseTypeId = newType.Id,
                    //ExerciseType = newType,
                    Show = true,
                };

                _context.Entry(property).State = EntityState.Added;

                return property;
            });
        }

        //TODO REFACTOR
        private IDictionary<string, List<string>> GetTagsDictionary(IReadOnlyList<string> groups, IReadOnlyList<string> tags)
        {
            var result = new Dictionary<string, List<string>>();

            for (var i = 0; i < groups.Count; i++)
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