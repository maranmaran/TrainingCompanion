using System.Linq;
using AutoMapper;

namespace Backend.Application.Business.Extensions
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
    }
}
