using Hangfire;
using Integrator.Configuration.Settings;
using Integrator.Jobs;

namespace Integrator.Hangfire
{
    public static class HangfireJobs
    {
        public static void AddHangfireJobs(HangfireSettings settings)
        {
            RecurringJob.AddOrUpdate<SynchronizationJob>(
                recurringJobId: "SyncJob",
                methodCall: job => job.Run(null!),
                cronExpression: settings.SyncJobCron
                );
        }

        public static void RemoveHangfireJobs()
        {
            RecurringJob.RemoveIfExists("SyncJob");
        }
    }
}
