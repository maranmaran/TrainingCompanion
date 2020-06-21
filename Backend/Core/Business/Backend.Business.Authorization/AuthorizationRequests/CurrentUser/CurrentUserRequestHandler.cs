using AutoMapper;
using Backend.Business.Billing.BillingRequests.GetPlans;
using Backend.Business.Billing.BillingRequests.GetSubscription;
using Backend.Business.Billing.BillingRequests.GetSubscriptionStatus;
using Backend.Business.ProgressTracking.BodyweightRequests.GetLatest;
using Backend.Common;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
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
                                            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

                if (user == null)
                    throw new NotFoundException(nameof(ApplicationUser), request.UserId);

                var response = _mapper.Map<CurrentUserRequestResponse>(user);

                await GetSubscriptionInformation(user, response, cancellationToken);
                await RefreshAvatar(user, response);
                await GetLatestBodyweight(user, response, cancellationToken);

                return response;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(CurrentUser), request.UserId, e);
            }
        }

        private async Task GetLatestBodyweight(ApplicationUser user, CurrentUserRequestResponse response,
            CancellationToken cancellationToken)
        {
            response.LatestBodyweight = await _mediator.Send(new GetLatestBodyweightRequest(user.Id), cancellationToken);
        }

        internal async Task RefreshAvatar(ApplicationUser user, CurrentUserRequestResponse response)
        {
            // refresh avatar url if needed
            if (GenericAvatarConstructor.IsGenericAvatar(user.Avatar) == false)
                response.Avatar = await _s3Service.GetPresignedUrlAsync(user.Avatar);
        }

        internal async Task GetSubscriptionInformation(ApplicationUser user,
            CurrentUserRequestResponse response, CancellationToken cancellationToken)
        {
            if (user.AccountType != AccountType.Coach
                && user.AccountType != AccountType.SoloAthlete)
            {
                return;
            }

            response.SubscriptionStatus =
                await _mediator.Send(new GetSubscriptionStatusRequest(response.CustomerId), cancellationToken);
            response.SubscriptionInfo =
                await _mediator.Send(new GetSubscriptionRequest(response.CustomerId), cancellationToken);
            response.Plans = await _mediator.Send(new GetPlansRequest(), cancellationToken);
        }
    }
}