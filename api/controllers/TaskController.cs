using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos;
using api.mappers;
using api.models;
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

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            // Econtrar task do banco de dados baseado no Id
            var task = _context.Tasks
                .ToList()
                .Select(i => i.ToTaskDTO())
                .FirstOrDefault(r => r.Id == id);

            if(task == null)
                return NotFound();
            
            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskRequestDTO taskDTO)
        {
            // Transformar DTO em objeto task
            TaskModel task = taskDTO.ToTaskFromRequestDTO();

            // Adicionar task ao banco de dados e salvar
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task.ToTaskDTO());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask([FromBody] TaskRequestDTO taskDTO, [FromRoute] int id)
        {
            var task = _context.Tasks.FirstOrDefault(r => r.Id == id);
            if (task == null)
                return NotFound();

            if (!string.IsNullOrEmpty(taskDTO.Titulo) && taskDTO.Titulo != task.Titulo)
                task.Titulo = taskDTO.Titulo;

            if (task.SlaHoras != taskDTO.SlaHoras)
                task.SlaHoras = taskDTO.SlaHoras;

            _context.SaveChanges();

            return Ok(task.ToTaskDTO());
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteTask([FromRoute] int id)
        {
            // Obter task do banco de dados pelo Id
            var task = _context.Tasks
                .FirstOrDefault(r => r.Id == id);

            if (task == null)
                return NotFound();

            // Remove task e salva alterações no banco de dados
            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return GetTasks();
        }
    }
}