using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.interfaces;
using api.mappers;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.services
{
    public class TaskSlaService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly INotificationService _notificationService;

        public TaskSlaService(ApplicationDBContext dbContext, INotificationService notificationService)
        {
            _dbContext = dbContext;
            _notificationService = notificationService;
        }

        public async Task CheckTasksForSlaExpirationAsync()
        {
            var now = DateTime.UtcNow;

            var tasks = await _dbContext.Tasks
                .Where(task => !task.Completo && task.HoraCriada.AddHours(task.SlaHoras) <= now)
                .ToListAsync();

            foreach (var task in tasks)
            {
                _notificationService.NotifyTaskExpired(task.ToTaskDTO());
            }
        }
    }
}