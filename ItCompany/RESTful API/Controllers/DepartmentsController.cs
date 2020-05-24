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

namespace RESTful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;
        
        public DepartmentsController(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }

        // GET: api/Departments
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_DepartmentService.GetAll().Data);
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!DepartmentExists(id))
            {
                return NotFound();
            }

            var Department = _DepartmentService.Get(id).Data;

            return Ok(Department);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] DepartmentDTO DepartmentDTO)
        {
            if (DepartmentExists(DepartmentDTO.Id))
            {
                return BadRequest();
            }

            _DepartmentService.Add(DepartmentDTO);
            
            return Ok(DepartmentDTO);
        }

        // DELETE: api/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!DepartmentExists(id))
            {
                return NotFound();
            }

            var Department = _DepartmentService.Get(id).Data;

            _DepartmentService.Delete(id);
            
            return Ok(Department);
        }

        [HttpPut()]
        public IActionResult Put([FromBody] DepartmentDTO item)
        {
            _DepartmentService.Update(item);
            return Ok(item);
        }

        private bool DepartmentExists(int id)
        {
            return _DepartmentService.GetAll().Data.Any(e => e.Id == id);
        }
    }
}
