using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Common;
using Backend.Domain.Entities.User;
using Backend.Service.AmazonS3.Interfaces;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Users.UsersRequests.GetAllUsers
{
    public class GetAllUsersRequestPostProcessor : IRequestPostProcessor<GetAllUsersRequest, IQueryable<ApplicationUser>>
    {
        private readonly IS3Service _s3;

        public GetAllUsersRequestPostProcessor(IS3Service s3)
        {
            _s3 = s3;
        }

        public async Task Process(GetAllUsersRequest request, IQueryable<ApplicationUser> response, CancellationToken cancellationToken)
        {
            var list = await response.ToListAsync(cancellationToken);

            var s3Avatars = list.Where(x => GenericAvatarConstructor.IsGenericAvatar(x.Avatar) == false); // must be s3 then if not generic
            foreach (var s3Avatar in s3Avatars)
            {
                s3Avatar.Avatar = await _s3.GetPresignedUrlAsync(s3Avatar.Avatar);
            }
        }
    }
}