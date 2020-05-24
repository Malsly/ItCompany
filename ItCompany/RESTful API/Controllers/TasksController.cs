using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Impl;
using Entities;
using BL.Abstract;
using Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace RESTful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _TaskService;
        
        public TasksController(ITaskService taskService)
        {
            _TaskService = taskService;
        }

        // GET: api/Tasks
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_TaskService.GetAll().Data);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!TaskExists(id))
            {
                return NotFound();
            }

            var task = _TaskService.Get(id).Data;

            return Ok(task);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] TaskDTO taskDTO)
        {
            if (TaskExists(taskDTO.Id))
            {
                return BadRequest();
            }

            _TaskService.Add(taskDTO);
            
            return Ok(taskDTO);
        }

        // DELETE: api/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!TaskExists(id))
            {
                return NotFound();
            }

            var task = _TaskService.Get(id).Data;

            _TaskService.Delete(id);
            
            return Ok(task);
        }

        [HttpPut()]
        public IActionResult Put([FromBody] TaskDTO item)
        {
            _TaskService.Update(item);
            return Ok(item);
        }

        private bool TaskExists(int id)
        {
            return _TaskService.GetAll().Data.Any(e => e.Id == id);
        }
    }
}
