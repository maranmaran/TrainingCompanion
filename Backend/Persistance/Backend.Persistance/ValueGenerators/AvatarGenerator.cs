using Backend.Common;
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Backend.Persistance.ValueGenerators
{
    public class AvatarGenerator : ValueGenerator<string>
    {
        public override string Next(EntityEntry entry)
        {
            return new GenericAvatarConstructor().AddName(((ApplicationUser)entry.Entity).FullName).Round().Background().Foreground("#ffffff").Value();
        }

        public override bool GeneratesTemporaryValues => false;
    }
}
