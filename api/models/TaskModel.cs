using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public double SlaHoras { get; set; }
        public bool Completo { get; set; }
        public DateTime HoraCriada { get; set; }
    }
}