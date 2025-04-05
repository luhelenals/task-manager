using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos;
using api.interfaces;

namespace api.services
{
    public class NotificationService : INotificationService
    {
        public void NotifyTaskExpired(TaskDTO task)
        {
            Console.WriteLine($"[ALERTA] A tarefa '{task.Titulo}' (ID: {task.Id}) excedeu o SLA!");
        }
    }
}