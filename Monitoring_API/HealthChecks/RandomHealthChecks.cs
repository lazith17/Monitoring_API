using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Monitoring_API.Controllers;

namespace Monitoring_API.HealthChecks
{
    public class RandomHealthChecks : IHealthCheck
    {
        //private readonly ILogger<RandomHealthChecks> _logger2;
        // public RandomHealthChecks(ILogger<RandomHealthChecks> logger2)
        // {
        //     _logger2 = logger2;
        // }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            int responseTimeInMs = Random.Shared.Next(300);
            //_logger2.LogInformation("The responce time is excellent ({responseTimeInMs})", responseTimeInMs);
            if (responseTimeInMs < 100)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy($"The responce time is excellent ({responseTimeInMs})")
                );
            }
            else if (responseTimeInMs < 200)
            {
                return Task.FromResult(
                    HealthCheckResult.Degraded($"The responce time is greater that expect ({responseTimeInMs})")
                );
            }
            else
            {
                return Task.FromResult(
                    HealthCheckResult.Unhealthy($"The responce time is unacceptable ({responseTimeInMs})")
                );
            }
        }
    }
}

//https://localhost:7063/healthchecks-ui#/healthchecks