using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TaskController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            // Obter tasks do banco de dados em formato de lista
            var tasks = _context.Tasks
                .ToList()
                .Select(i => i.ToTaskDTO());

            return Ok(tasks);
        }
    }
}