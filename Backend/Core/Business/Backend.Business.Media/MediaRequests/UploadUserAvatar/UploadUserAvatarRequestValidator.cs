using FluentValidation;

namespace Backend.Business.Media.MediaRequests.UploadUserAvatar
{
    public class UploadUserAvatarRequestValidator : AbstractValidator<UploadUserAvatarRequest>
    {
        public UploadUserAvatarRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Base64).NotEmpty().WithMessage("File must be image. Try jpeg or png extensions!");
        }
    }
}