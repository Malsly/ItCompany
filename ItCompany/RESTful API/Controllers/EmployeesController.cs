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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;
        
        public EmployeesController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_EmployeeService.GetAll().Data);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!EmployeeExists(id))
            {
                return NotFound();
            }

            var Employee = _EmployeeService.Get(id).Data;

            return Ok(Employee);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] EmployeeDTO EmployeeDTO)
        {
            if (EmployeeExists(EmployeeDTO.Id))
            {
                return BadRequest();
            }

            _EmployeeService.Add(EmployeeDTO);
            
            return Ok(EmployeeDTO);
        }

        // DELETE: api/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!EmployeeExists(id))
            {
                return NotFound();
            }

            var Employee = _EmployeeService.Get(id).Data;

            _EmployeeService.Delete(id);
            
            return Ok(Employee);
        }

        [HttpPut()]
        public IActionResult Put([FromBody] EmployeeDTO item)
        {
            _EmployeeService.Update(item);
            return Ok(item);
        }

        private bool EmployeeExists(int id)
        {
            return _EmployeeService.GetAll().Data.Any(e => e.Id == id);
        }
    }
}
