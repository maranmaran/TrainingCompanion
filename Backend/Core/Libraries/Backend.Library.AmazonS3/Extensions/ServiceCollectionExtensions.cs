using Backend.Library.AmazonS3.Interfaces;
using Backend.Library.AmazonS3.Storages;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Backend.Library.AmazonS3.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configure S3 as storage provider
        /// </summary>
        public static void ConfigureS3Storage(this IServiceCollection services, Action<IStorageSettings> options = null)
        {
            var settings = new S3StorageSettings();
            options?.Invoke(settings);

            var validationResult = new StorageSettingsValidator().Validate(settings);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            services.AddSingleton<IStorageSettings>(settings);
            services.AddTransient<IStorage, S3Storage>();
        }

        /// <summary>
        /// Configure Firebase as storage provider
        /// </summary>
        public static void ConfigureFirebaseStorage(this IServiceCollection services, Action<IStorageSettings> options = null)
        {
            var settings = new FirebaseStorageSettings();
            options?.Invoke(settings);

            var validationResult = new StorageSettingsValidator().Validate(settings);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            services.AddSingleton<IStorageSettings>(settings);
            services.AddTransient<IStorage, FirebaseStorage>();
        }
    }
}