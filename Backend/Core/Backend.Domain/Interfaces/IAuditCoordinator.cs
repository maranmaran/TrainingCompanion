﻿using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.User;
using System.Threading.Tasks;

namespace Backend.Domain.Interfaces
{
    public interface IAuditCoordinator
    {
        Task PushToCoach(AuditRecord audit, Athlete athlete);
    }
}
