using FluentValidation;

namespace Backend.Library.AmazonS3
{
    internal class StorageSettingsValidator : AbstractValidator<IStorageSettings>
    {
        public StorageSettingsValidator()
        {
            RuleFor(x => x.AccessKey).NotEmpty().WithMessage("Storage access key is required");
            RuleFor(x => x.SecretKey).NotEmpty().WithMessage("Storage secret key is required");
            RuleFor(x => x.BucketName).NotEmpty().WithMessage("Storage bucket name is required");
            RuleFor(x => x.UrlBase).NotEmpty().WithMessage("Storage url base is required");
        }
    }
}