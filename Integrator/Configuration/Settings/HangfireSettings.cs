namespace Integrator.Configuration.Settings
{
    public record HangfireSettings
    {
        public string? SyncJobCron { get; set; }
    }
}
