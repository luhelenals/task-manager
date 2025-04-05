using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.dtos
{
    public class TaskRequestDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public double SlaHoras { get; set; }
    }
}