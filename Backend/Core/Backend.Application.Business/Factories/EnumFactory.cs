using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace Backend.Persistance.Seed
{
    public static class EnumFactory
    {
        public static IEnumerable<TClass> SeedEnum<TEnum, TClass>(Func<TEnum, TClass> factory) 
            where TEnum: struct 
            where TClass : class
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<object>()
                .Select(value => factory(((TEnum)value)))
                .ToList();

        }
    }
}
