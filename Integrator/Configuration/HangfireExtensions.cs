using Hangfire;
using Hangfire.Console;
using Integrator.Configuration.Settings;
using Integrator.Hangfire;

namespace Integrator.Configuration
{
    public static class HangfireExtensions
    {
        public static IServiceCollection RegisterHangfire(this IServiceCollection services, ConnectionStrings connectionStrings, HangfireSettings hangfireSettings)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionStrings.HangfireDatabase);
            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(connectionStrings.HangfireDatabase);
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180);
                config.UseSimpleAssemblyNameTypeSerializer();
                config.UseRecommendedSerializerSettings();
                config.UseConsole();
            });

            HangfireJobs.AddHangfireJobs(hangfireSettings);

            return services;
        }

        public static void AddHangfireDashboard(this WebApplication app)
        {
            app.UseHangfireDashboard("/hangfire", options: new DashboardOptions
            {
                 DisplayStorageConnectionString = false,
                 DashboardTitle = "Integrator",
                 Authorization = [new HangfireAuthFilter()]
            });
        }
    }
}
