using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Application.Business.Factories
{
    public static class EnumFactory
    {
        public static IEnumerable<TClass> SeedEnum<TEnum, TClass>(Func<TEnum, TClass> factory)
            where TEnum : struct
            where TClass : class
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<object>()
                .Select(value => factory(((TEnum)value)))
                .ToList();
        }
    }
}