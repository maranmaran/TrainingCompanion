using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace Backend.Persistance.ValueGenerators
{
    public class GuidGenerator : ValueGenerator<string>
    {
        public override string Next(EntityEntry entry)
        {
            return Guid.NewGuid().ToString();
        }

        public override bool GeneratesTemporaryValues => false;
    }
}