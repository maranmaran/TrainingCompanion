using MediatR;

namespace Backend.Business.TrainingLog.SetRequests.Create
{
    public class CreateSetRequest : IRequest<Domain.Entities.TrainingLog.Set>
    {
    }
}