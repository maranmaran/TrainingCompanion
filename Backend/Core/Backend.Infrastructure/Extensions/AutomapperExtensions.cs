using AutoMapper;
using System.Linq;

namespace Backend.Infrastructure.Extensions
{
    public static class AutomapperExtensions
    {
        public static IMappingExpression<TSource, TDestination>
            IgnoreAllVirtual<TSource, TDestination>(
                this IMappingExpression<TSource, TDestination> expression)
        {
            var desType = typeof(TDestination);
            foreach (var property in desType.GetProperties().Where(p =>
                p.GetGetMethod().IsVirtual))
            {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }

            return expression;
        }

        public static TEntity NullfyVirtualProperties<TEntity>(this TEntity entity) where TEntity : class
        {
            var desType = typeof(TEntity);
            foreach (var property in desType.GetProperties().Where(p => p.GetGetMethod().IsVirtual))
            {
                property.SetValue(entity, null);
            }

            return entity;
        }
    }
}