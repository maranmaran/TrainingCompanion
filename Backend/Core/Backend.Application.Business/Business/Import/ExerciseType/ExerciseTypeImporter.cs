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
        private readonly IDictionary<string, Domain.Entities.ExerciseType.Tag> _existingTags;
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

        private IEnumerable<ExerciseTypeTag> ParseExerciseTypeProperties(string importGroups, string importTags)
        {
            // parse to some kind of better collection that represents nesting
            var tagsDict = GetTagsDictionary(importGroups, importTags);

            var result = new List<Domain.Entities.ExerciseType.TagGroup>();

            foreach (var (group, tags) in tagsDict)
            {
                if (_existingGroups.TryGetValue(group, out var existingTagGroup))
                {
                    HandleExistingTagGroup(tags, existingTagGroup, result);
                }
                else
                {
                    HandleNewTagGroup(group, tags, result);
                }
            }

            var properties = GetExerciseProperties(result);
            return properties;
        }

        /// <summary>
        ///
        /// Group exists
        ///     Tag exists - just add to result
        ///     New Tag
        ///         Add it to context
        ///         Modify existing group
        ///         Add it to cache
        ///
        /// </summary>
        private void HandleExistingTagGroup(IEnumerable<string> importedTags, Domain.Entities.ExerciseType.TagGroup existingGroup, List<Domain.Entities.ExerciseType.TagGroup> result)
        {
            if (result == null) throw new ArgumentNullException(nameof(result));

            var tagsToAdd = importedTags.Select(tag =>
            {
                var tagToAdd = existingGroup.Tags.FirstOrDefault(x => x.Value == tag);
                if (tagToAdd == null)
                {
                    if (!_existingTags.TryGetValue(tag, out tagToAdd))
                    {
                        tagToAdd = new Domain.Entities.ExerciseType.Tag()
                        {
                            Id = Guid.NewGuid(),
                            Value = tag
                        };

                        _existingTags.Add(tagToAdd.Value, tagToAdd);
                    }

                    _context.Entry(tagToAdd).State = EntityState.Added;
                }

                return tagToAdd;
            }).ToList();

            existingGroup.Tags = tagsToAdd;

            result.Add(existingGroup);
            _context.Entry(existingGroup).State = EntityState.Modified;
        }

        /// <summary>
        /// Group does not exist
        ///     Create group
        ///         Add group to cache
        ///         Modify context to add it
        ///     Add all tags to group
        ///         Modify context to add all tags
        ///         Add tags to cache
        /// </summary>
        private void HandleNewTagGroup(string importedGroup, List<string> importedTags, List<Domain.Entities.ExerciseType.TagGroup> result)
        {
            var newTags = importedTags.Select(x =>
            {
                var newTag = new Domain.Entities.ExerciseType.Tag
                {
                    Id = Guid.NewGuid(),
                    Value = x,
                };

                _context.Entry(newTag).State = EntityState.Added;

                return newTag;
            }).ToList();

            var newTagGroup = new Domain.Entities.ExerciseType.TagGroup
            {
                Id = Guid.NewGuid(),
                ApplicationUserId = _userId,
                Type = importedGroup,
                Tags = newTags
            };

            _existingGroups[newTagGroup.Type] = newTagGroup;
            _context.Entry(newTagGroup).State = EntityState.Added;

            result.Add(newTagGroup);
        }

        /// <summary>
        /// Constructs exercise properties from given tag groups
        /// </summary>
        /// <param name="tagGroups"></param>
        /// <returns></returns>
        private IEnumerable<ExerciseTypeTag> GetExerciseProperties(IEnumerable<Domain.Entities.ExerciseType.TagGroup> tagGroups)
        {
            var tags = tagGroups.SelectMany(x =>
            {
                x.Tags.ToList().ForEach(y => y.TagGroup = x);
                return x.Tags;
            });

            return tags.Select(x =>
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

        /// <summary>
        /// Converts single line imports of groups and their tags to some meaningful structure. Groups has many tags
        /// </summary>
        private IDictionary<string, List<string>> GetTagsDictionary(string importGroups, string importTags)
        {
            var groups = importGroups.Split(",").Select(x => x.Trim()).ToArray();
            var tags = importTags.Split(",").Select(x => x.Trim()).ToArray();

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