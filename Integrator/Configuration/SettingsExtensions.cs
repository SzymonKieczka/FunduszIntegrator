using Integrator.Configuration.Settings;

namespace Integrator.Configuration
{
    public static class SettingsExtensions
    {
        public static ApplicationSettings RegisterSettings(this IServiceCollection services)
        {
            ConnectionStrings connectionStrings = new();
            HangfireSettings hangfireSettings = new();

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            env = string.IsNullOrWhiteSpace(env) ? "Production" : env;

            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{env}.json", false)
                .Build();

            services.AddOptions();
            config.GetSection("ConnectionStrings").Bind(connectionStrings);
            config.GetSection("HangfireSettings").Bind(hangfireSettings);
            services.Configure<ConnectionStrings>(options => config.GetSection("ConnectionStrings").Bind(connectionStrings));
            services.Configure<HangfireSettings>(options => config.GetSection("HangfireSettings").Bind(hangfireSettings));

            return new ApplicationSettings
            {
                ConnectionStrings = connectionStrings,
                HangfireSettings = hangfireSettings,
            };
        }
    }
}
