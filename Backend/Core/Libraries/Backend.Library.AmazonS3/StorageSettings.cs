using FluentValidation;
using System;

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

    public interface IStorageSettings
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }

        public string UrlBase { get; set; }
    }

    internal class S3StorageSettings : IStorageSettings
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }

        public string UrlBase { get; set; }

        public S3StorageSettings()
        {
        }

        public S3StorageSettings(string accessKey, string secretKey, string bucketName)
        {
            if (string.IsNullOrWhiteSpace(accessKey))
                throw new ArgumentNullException(nameof(accessKey));
            if (string.IsNullOrWhiteSpace(secretKey))
                throw new ArgumentNullException(nameof(secretKey));
            if (string.IsNullOrWhiteSpace(bucketName))
                throw new ArgumentNullException(nameof(bucketName));

            AccessKey = accessKey;
            SecretKey = secretKey;
            BucketName = bucketName;
        }
    }

    internal class FirebaseStorageSettings : IStorageSettings
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string BucketName { get; set; }

        public string UrlBase { get; set; }

        public FirebaseStorageSettings()
        {
        }

        public FirebaseStorageSettings(string accessKey, string secretKey, string bucketName)
        {
            if (string.IsNullOrWhiteSpace(accessKey))
                throw new ArgumentNullException(nameof(accessKey));
            if (string.IsNullOrWhiteSpace(secretKey))
                throw new ArgumentNullException(nameof(secretKey));
            if (string.IsNullOrWhiteSpace(bucketName))
                throw new ArgumentNullException(nameof(bucketName));

            AccessKey = accessKey;
            SecretKey = secretKey;
            BucketName = bucketName;
        }
    }
}