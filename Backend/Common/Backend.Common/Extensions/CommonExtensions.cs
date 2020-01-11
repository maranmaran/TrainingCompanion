using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Common.Extensions
{
    public static class CommonExtensions
    {
        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public static IQueryable<TEntity> Sort<TEntity, TKey>(
            this IQueryable<TEntity> collection,
            Expression<Func<TEntity, TKey>> selector,
            string direction)
            where TEntity : class
        {
            if (direction == "asc")
            {
                return collection.OrderBy(selector);
            }

            if (direction == "desc")
            {
                return collection.OrderByDescending(selector);
            }

            return collection;
        }

        public static async Task<byte[]> ToByteArray(this Stream stream, CancellationToken cancellationToken = default)
        {
            await using var memStream = new MemoryStream();
            await stream.CopyToAsync(memStream, cancellationToken);

            return memStream.ToArray();
        }
    }
}