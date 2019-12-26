using Backend.API.Extensions;
using Backend.API.Middleware;
using Backend.Application.Business.Business.Chat;
using Backend.Application.Business.Business.PushNotification;
using Backend.Application.Business.Extensions;
using Backend.Service.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Backend.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // third party libraries
            services.ConfigureSieve(Configuration);
            services.ConfigureAutomapper();
            services.ConfigureMediatR();
            services.ConfigureSignalR();

            // setting and services from core
            services.ConfigureCoreSettings(Configuration);
            services.ConfigureCoreServices();

            // application configuration CORS, Auth, Swagger, MVC, DB
            services.ConfigureDatabase(Configuration.GetConnectionString("DefaultConnection"));
            services.ConfigureJwtAuth(Configuration);
            services.ConfigureCors();
            services.ConfigureMvc();
            services.ConfigureSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            // ===== SPA angular setup (wwwroot folder) =====
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // https://docs.microsoft.com/en-us/aspnet/core/migration/22-to-30?view=aspnetcore-3.0&tabs=visual-studio
            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseCors("AllowAllCorsPolicy");
                //app.UseMiddleware<MaintainCorsHeadersMiddleware>();

                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // ===== Middleware to serve generated Swagger as a JSON endpoint and serve swagger-ui =====
            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Backend API v1.0");
                setup.RoutePrefix = "api";
                setup.DocExpansion(DocExpansion.None);
            });

            // ===== Payment api configuration - Stripe.com =====
            StripeConfiguration.ApiKey = Configuration["StripeSettings:SecretKey"];

            // ===== Authentication  =====
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseMiddleware<JwtToAuthHeaderMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            // ===== SignalR Hubs configuration AND Controllers ( API ) configuration =====
            // =====  MUST BE AFTER AUTHENTICATION=====
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<PushNotificationHub>("/api/notifications-hub");
                endpoints.MapHub<ChatHub>("/api/chat-hub");
            });

            // ===== Global error handling middleware with logging =====
            app.UseHttpsRedirection();
        }
    }
}