using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos;

namespace api.interfaces
{
    public interface INotificationService
    {
        void NotifyTaskExpired(TaskDTO task);
    }
}