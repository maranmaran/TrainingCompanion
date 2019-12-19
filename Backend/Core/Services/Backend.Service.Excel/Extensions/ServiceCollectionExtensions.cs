using Backend.Service.Excel.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Service.Excel.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static void ConfigureExcelService(this IServiceCollection services)
        {
            services.AddTransient<IExcelService, ExcelService>();
        }
    }
}