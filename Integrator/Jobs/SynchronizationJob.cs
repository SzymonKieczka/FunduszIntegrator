using Hangfire.Server;

namespace Integrator.Jobs
{
    public class SynchronizationJob
    {
        public void Run(PerformContext context)
        {
            Console.WriteLine("job runs!");
        }
    }
}
