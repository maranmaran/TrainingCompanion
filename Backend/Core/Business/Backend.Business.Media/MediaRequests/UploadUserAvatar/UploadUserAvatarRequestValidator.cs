using Backend.Common.Extensions;
using FluentValidation;

namespace Backend.Business.Media.MediaRequests.UploadUserAvatar
{
    public class UploadUserAvatarRequestValidator : AbstractValidator<UploadUserAvatarRequest>
    {
        public UploadUserAvatarRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.File).Must(x => x.IsImage()).WithMessage("File must be image. Try jpeg or png extensions!");
        }
    }
}