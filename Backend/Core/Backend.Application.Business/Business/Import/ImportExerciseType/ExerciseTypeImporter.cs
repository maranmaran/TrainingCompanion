using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.ExerciseType;
using Backend.Service.Excel.Models.Import.ExerciseType;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Import.ImportExerciseType
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
        private readonly ConcurrentDictionary<string, Domain.Entities.ExerciseType.TagGroup> _existingGroups;
        private readonly ConcurrentDictionary<string, Domain.Entities.ExerciseType.ExerciseType> _existingTypes;

        public ExerciseTypeImporter(IApplicationDbContext context, Guid userId, IMapper mapper)
        {
            _context = context;
            _userId = userId;
            _mapper = mapper;

            var existingTypes = _context
                .ExerciseTypes
                .Include(x => x.Properties)
                .Where(x => x.ApplicationUserId == userId)
                //.AsNoTracking()
                .ToDictionary(x => x.Code, x => x)
                .ToList();

            _existingTypes = new ConcurrentDictionary<string, Domain.Entities.ExerciseType.ExerciseType>(existingTypes);

            var existingGroups = _context
                .TagGroups
                .Include(x => x.Tags)
                .Where(x => x.ApplicationUserId == userId)
                //.AsNoTracking()
                .ToDictionary(x => x.Type, x => x)
                .ToList();

            _existingGroups = new ConcurrentDictionary<string, Domain.Entities.ExerciseType.TagGroup>(existingGroups);
        }

        public async Task DoImport(IEnumerable<ImportExerciseTypeDto> data, CancellationToken cancellationToken = default)
        {
            //Parallel.ForEach(
            //    source: data, 
            //    body: DoWork,
            //    () => { }
            //);

            foreach (var row in data)
            {
                DoWork(row, null);
            }


            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new Exception("Concurrency exception", e);
            }
        }

        private void DoWork(ImportExerciseTypeDto row, ParallelLoopState loopState)
        {
            // parse all tags and tag groups and assign exercise properties (join table entity) on exercise type
            var properties = new List<ExerciseTypeTag>();
            if (!string.IsNullOrWhiteSpace(row.Tags) && !string.IsNullOrWhiteSpace(row.TagGroups))
                properties = ParseExerciseTypeProperties(row.TagGroups, row.Tags).ToList();

            // parse and get exercise type from data row
            ParseExerciseType(row, properties);
        }

        private void ParseExerciseType(ImportExerciseTypeDto row, List<ExerciseTypeTag> properties)
        {
            _existingTypes.TryGetValue(row.Code, out var existingType);

            var type = _mapper.Map<Domain.Entities.ExerciseType.ExerciseType>(row);

            if (existingType != null)
            {
                type = existingType;

                type.ApplicationUserId = _userId;

                // remove existing properties
                foreach (var property in existingType.Properties)
                {
                    //_context.Entry(property).State = EntityState.Deleted;
                    _context.ExerciseTypeTags.Remove(property);
                }

                // assign new properties
                type.Properties = properties;
                _context.Entry(type).State = EntityState.Modified;

                foreach (var property in type.Properties)
                {
                    property.ExerciseTypeId = type.Id;
                    _context.Entry(property).State = EntityState.Added;
                }
                //_context.Entry(type).State = EntityState.Modified;
            }
            else
            {
                type.Id = Guid.NewGuid();

                type.ApplicationUserId = _userId;
                type.Properties = properties;
                _context.Entry(type).State = EntityState.Added;

                foreach (var property in type.Properties)
                {
                    property.ExerciseTypeId = type.Id;
                    _context.Entry(property).State = EntityState.Added;
                }
                //_context.Entry(type).State = EntityState.Added;
                _context.ExerciseTypes.Add(type);
            }

            _existingTypes.AddOrUpdate(type.Code, (id) => type, (id, item) => type);
        }

        private IEnumerable<ExerciseTypeTag> ParseExerciseTypeProperties(string importGroups, string importTags)
        {
            // parse to some kind of better collection that represents nesting
            var tagsDict = GetTagsDictionary(importGroups, importTags);

            var resultGroups = new Dictionary<Guid, Domain.Entities.ExerciseType.TagGroup>();
            var resultTags = new Dictionary<Guid, Domain.Entities.ExerciseType.Tag>();

            foreach (var (group, tags) in tagsDict)
            {
                if (_existingGroups.TryGetValue(group, out var existingTagGroup))
                {
                    HandleExistingTagGroup(tags, existingTagGroup, resultGroups, resultTags);
                }
                else
                {
                    HandleNewTagGroup(group, tags, resultGroups, resultTags);
                }
            }

            var properties = GetExerciseProperties(resultTags);
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
        private void HandleExistingTagGroup(IEnumerable<string> importedTags, Domain.Entities.ExerciseType.TagGroup existingGroup, Dictionary<Guid, Domain.Entities.ExerciseType.TagGroup> resultGroups, Dictionary<Guid, Domain.Entities.ExerciseType.Tag> resultTags)
        {
            foreach (var importedTagStr in importedTags)
            {
                var tag = existingGroup.Tags.FirstOrDefault(x => x.Value == importedTagStr);

                if (tag == null)
                {
                    tag = new Domain.Entities.ExerciseType.Tag()
                    {
                        Id = Guid.NewGuid(),
                        Value = importedTagStr,
                        TagGroupId = existingGroup.Id
                    };

                    existingGroup.Tags.Add(tag);

                    _context.Entry(existingGroup).State = _context.Entry(existingGroup).State != EntityState.Added ? EntityState.Modified : EntityState.Added;

                    _context.Entry(tag).State = EntityState.Added;

                    //_context.Tags.Add(tag);
                }

                resultGroups[existingGroup.Id] = existingGroup;
                resultTags[tag.Id] = tag;

            }

            //_context.Entry(existingGroup).State = EntityState.Modified;

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
        private void HandleNewTagGroup(string importedGroup, List<string> importedTags, Dictionary<Guid, Domain.Entities.ExerciseType.TagGroup> resultGroups, Dictionary<Guid, Domain.Entities.ExerciseType.Tag> resultTags)
        {
            var newTagGroup = new Domain.Entities.ExerciseType.TagGroup
            {
                Id = Guid.NewGuid(),
                ApplicationUserId = _userId,
                Type = importedGroup,
                Active = true,
            };

            var newTags = importedTags.Select(x =>
            {
                var newTag = new Domain.Entities.ExerciseType.Tag
                {
                    Id = Guid.NewGuid(),
                    TagGroupId = newTagGroup.Id,
                    Value = x,
                };

                //_context.Entry(newTag).State = EntityState.Added;
                _context.Tags.Add(newTag);

                resultTags[newTag.Id] = newTag;

                return newTag;
            }).ToList();

            newTagGroup.Tags = newTags;

            _existingGroups.AddOrUpdate(newTagGroup.Type, (id) => newTagGroup, (id, group) => group = newTagGroup); ;
            _context.TagGroups.Add(newTagGroup);
            //_context.Entry(newTagGroup).State = EntityState.Added;

            resultGroups[newTagGroup.Id] = newTagGroup;
        }

        /// <summary>
        /// Constructs exercise properties from given tag groups
        /// </summary>
        /// <param name="tagGroups"></param>
        /// <returns></returns>
        private IEnumerable<ExerciseTypeTag> GetExerciseProperties(Dictionary<Guid, Domain.Entities.ExerciseType.Tag> tagsDict)
        {
            var tags = tagsDict.Values;

            // now from all tags create exercise property 
            return tags.Select(tag =>
            {
                var property = new ExerciseTypeTag
                {
                    TagId = tag.Id,
                    Show = true,
                };

                //_context.Entry(property).State = EntityState.Added;
                _context.ExerciseTypeTags.Add(property);

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