using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.dtos
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public double SlaHoras { get; set; }
        public bool Completo { get; set; }
        public DateTime HoraCriada { get; set; }
    }
}