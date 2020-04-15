using Backend.Domain.Entities.Auditing;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Interfaces
{
    public interface IActivityService
    {
        //Task<string> GetPayload(AuditRecord audit, UserSetting settings);
        Task<string> GetEntityAsJson(AuditRecord audit);
    }
}