namespace Integrator.Configuration.Settings
{
    public class ApplicationSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; } = new();
        public HangfireSettings HangfireSettings { get; set; } = new();
    }
}
