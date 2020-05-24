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
    public class EmployeeDepartmentsController : ControllerBase
    {
        private readonly IEmployeeDepartmentService _EmployeeDepartmentService;
        
        public EmployeeDepartmentsController(IEmployeeDepartmentService EmployeeDepartmentService)
        {
            _EmployeeDepartmentService = EmployeeDepartmentService;
        }

        // GET: api/EmployeeDepartments
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_EmployeeDepartmentService.GetAll().Data);
        }

        // GET: api/EmployeeDepartments/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!EmployeeDepartmentExists(id))
            {
                return NotFound();
            }

            var EmployeeDepartment = _EmployeeDepartmentService.Get(id).Data;

            return Ok(EmployeeDepartment);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] EmployeeDepartmentDTO EmployeeDepartmentDTO)
        {
            if (EmployeeDepartmentExists(EmployeeDepartmentDTO.Id))
            {
                return BadRequest();
            }

            _EmployeeDepartmentService.Add(EmployeeDepartmentDTO);
            
            return Ok(EmployeeDepartmentDTO);
        }

        // DELETE: api/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!EmployeeDepartmentExists(id))
            {
                return NotFound();
            }

            var EmployeeDepartment = _EmployeeDepartmentService.Get(id).Data;

            _EmployeeDepartmentService.Delete(id);
            
            return Ok(EmployeeDepartment);
        }

        [HttpPut()]
        public IActionResult Put([FromBody] EmployeeDepartmentDTO item)
        {
            _EmployeeDepartmentService.Update(item);
            return Ok(item);
        }

        private bool EmployeeDepartmentExists(int id)
        {
            return _EmployeeDepartmentService.GetAll().Data.Any(e => e.Id == id);
        }
    }
}
