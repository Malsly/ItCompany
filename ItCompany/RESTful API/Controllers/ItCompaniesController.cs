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
    public class ItCompanysController : ControllerBase
    {
        private readonly IItCompanyService _ItCompanyService;
        
        public ItCompanysController(IItCompanyService ItCompanyService)
        {
            _ItCompanyService = ItCompanyService;
        }

        // GET: api/ItCompanys
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ItCompanyService.GetAll().Data);
        }

        // GET: api/ItCompanys/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!ItCompanyExists(id))
            {
                return NotFound();
            }   

            var ItCompany = _ItCompanyService.Get(id).Data;

            return Ok(ItCompany);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] ItCompanyDTO ItCompanyDTO)
        {
            if (ItCompanyExists(ItCompanyDTO.Id))
            {
                return BadRequest();
            }

            _ItCompanyService.Add(ItCompanyDTO);
            
            return Ok(ItCompanyDTO);
        }

        // DELETE: api/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ItCompanyExists(id))
            {
                return NotFound();
            }

            var ItCompany = _ItCompanyService.Get(id).Data;

            _ItCompanyService.Delete(id);
            
            return Ok(ItCompany);
        }

        [HttpPut()]
        public IActionResult Put([FromBody] ItCompanyDTO item)
        {
            _ItCompanyService.Update(item);
            return Ok(item);
        }

        private bool ItCompanyExists(int id)
        {
            return _ItCompanyService.GetAll().Data.Any(e => e.Id == id);
        }
    }
}
