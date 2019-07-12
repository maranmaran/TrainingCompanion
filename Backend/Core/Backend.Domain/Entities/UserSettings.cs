using Backend.Domain.Enum;
using System;

namespace Backend.Domain.Entities
{
    public class UserSettings
    {
        public Guid Id { get; set; }
        public Themes Theme { get; set; }
    }
}
