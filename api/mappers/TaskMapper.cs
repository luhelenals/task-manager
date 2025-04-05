using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos;
using api.models;

namespace api.mappers
{
    public static class TaskMapper
    {
        public static TaskDTO ToTaskDTO(this TaskModel task)
        {
            return new TaskDTO
            {
                Id = task.Id,
                Titulo = task.Titulo,
                SlaHoras = task.SlaHoras
            };
        }

        public static TaskModel ToTaskFromRequestDTO(this TaskRequestDTO task)
        {
            return new TaskModel
            {
                Titulo = task.Titulo,
                SlaHoras = task.SlaHoras
            };
        }
    }
}