using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.services
{
    public class SlaMonitorService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public SlaMonitorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var taskSlaService = scope.ServiceProvider.GetRequiredService<TaskSlaService>();
                    await taskSlaService.CheckTasksForSlaExpirationAsync();
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}