using Microsoft.Extensions.DependencyInjection;

namespace Backend.Library.Excel.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static void ConfigureExcelService(this IServiceCollection services)
        {
            //services.AddTransient<IExcelService, ExcelService>();
        }
    }
}