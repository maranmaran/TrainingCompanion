using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.User;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard.Interfaces
{
    public interface IActivityService
    {
        Task<string> GetPayload(AuditRecord audit, UserSetting settings);
        string GetEntityAsJson(AuditRecord audit);
    }
}