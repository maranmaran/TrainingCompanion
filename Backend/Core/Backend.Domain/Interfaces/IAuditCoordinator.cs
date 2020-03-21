using Backend.Domain.Entities.Auditing;
using System.Threading.Tasks;

namespace Backend.Domain.Interfaces
{
    public interface IAuditCoordinator
    {
        Task Push(AuditRecord audit);
    }
}
