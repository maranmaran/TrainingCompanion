using AutoMapper;
using Backend.Business.Billing.BillingRequests.GetPlans;
using Backend.Business.Billing.BillingRequests.GetSubscription;
using Backend.Business.Billing.BillingRequests.GetSubscriptionStatus;
using Backend.Common;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Service.AmazonS3.Interfaces;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Authorization.AuthorizationRequests.CurrentUser
{
    public class CurrentUserRequestHandler : IRequestHandler<CurrentUserRequest, CurrentUserRequestResponse>
    {
        private readonly IMapper _mapper;
        private readonly IS3Service _s3Service;
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public CurrentUserRequestHandler(IMapper mapper, IApplicationDbContext context, IMediator mediator, IS3Service s3Service)
        {
            _mapper = mapper;
            _context = context;
            _mediator = mediator;
            _s3Service = s3Service;
        }

        public async Task<CurrentUserRequestResponse> Handle(CurrentUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users
                                            .Include(x => x.UserSetting)
                                            .ThenInclude(x => x.NotificationSettings)
                                            .SingleAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

                if (user == null) throw new NotFoundException(nameof(ApplicationUser), request.UserId);

                var response = _mapper.Map<CurrentUserRequestResponse>(user);

                if (user.AccountType == AccountType.Coach || user.AccountType == AccountType.SoloAthlete)
                {
                    response.SubscriptionStatus = await _mediator.Send(new GetSubscriptionStatusRequest(response.CustomerId), cancellationToken);
                    response.SubscriptionInfo = await _mediator.Send(new GetSubscriptionRequest(response.CustomerId), cancellationToken);
                    response.Plans = await _mediator.Send(new GetPlansRequest(), cancellationToken);
                }

                // refresh avatar url if needed
                if (GenericAvatarConstructor.IsGenericAvatar(user.Avatar) == false)
                    user.Avatar = await _s3Service.GetPresignedUrlAsync(user.Avatar);

                return response;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(CurrentUser), request.UserId, e);
            }
        }
    }
}