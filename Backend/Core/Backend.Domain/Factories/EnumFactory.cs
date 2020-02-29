using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Domain.Factories
{
    public static class EnumFactory
    {
        public static IEnumerable<TClass> SeedEnum<TEnum, TClass>(Func<TEnum, TClass> factory)
            where TEnum : struct
            where TClass : class
        {
            return System.Enum.GetValues(typeof(TEnum))
                .Cast<object>()
                .Select(value => factory(((TEnum)value)))
                .ToList();
        }
    }
}