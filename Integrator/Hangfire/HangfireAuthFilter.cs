using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Integrator.Hangfire
{
    public class HangfireAuthFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            // TODO: auth
            return true;
        }
    }
}
