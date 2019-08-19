using Backend.Domain.Enum;
using System;

namespace Backend.Domain.Entities.User
{
    public class UserSettings
    {
        public Guid Id { get; set; }
        public Themes Theme { get; set; }
        public UnitSystem UnitSystem { get; set; }
        public bool UseRpeSystem { get; set; }
        public RpeSystem RpeSystem { get; set; }
    }
}
