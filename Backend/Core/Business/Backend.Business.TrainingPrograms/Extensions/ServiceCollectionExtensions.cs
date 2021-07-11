using Backend.Business.TrainingPrograms.Interfaces;
using Backend.Business.TrainingPrograms.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Business.TrainingPrograms.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures Core training program services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureTrainingProgramServices(this IServiceCollection services)
        {
            services.AddTransient<ITrainingProgramAssignService, TrainingProgramAssignService>();
        }
    }
}