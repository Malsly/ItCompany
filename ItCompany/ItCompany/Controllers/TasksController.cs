using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Impl;
using Entities;
using BL.Abstract;
using Models;
using ItCompany.ViewDataParams;

namespace ItCompany.Controllers
{
    public class TasksController : Controller
    {

        private readonly ITaskService _TaskService;
        private readonly IEmployeeService _EmployeeService;
        private readonly IDepartmentService _DepartmentService;


        public TasksController(ITaskService taskService, IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _TaskService = taskService;
            _EmployeeService = employeeService;
            _DepartmentService = departmentService;
        }

        // GET: Tasks
        public ActionResult<IEnumerable<TaskDTO>> Index([FromForm] string[] filters)
        {
            return View(_TaskService.GetAll().Data);
        }

        // GET: [controller]/Details/5
        [HttpGet("[controller]/Details/{id}")]
        public ActionResult<TaskDTO> Details(int id)
        {
            var item = _TaskService.Get(id).Data;
            if (item == null)
                return NotFound();
            return View(item);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ConfigureViewData();
            return View();
        }


        // POST: [controller]/Create
        [HttpPost("[controller]/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] TaskDTO item)
        {
            if (ModelState.IsValid)
            {
                _TaskService.Add(item);
                return RedirectToAction(nameof(Index));
            }

            ConfigureViewData();
            return View(item);
        }

        // GET: [controller]/Edit/5
        [HttpGet("[controller]/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var item = _TaskService.Get(id).Data;
            if (item == null)
                return NotFound();
            ConfigureViewData(item);
            return View(item);
        }

        // POST: [controller]/Edit/5
        [HttpPost("[controller]/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [FromForm] TaskDTO item)
        {
            if (ModelState.IsValid)
            {
                _TaskService.Update(item);
                return RedirectToAction(nameof(Index));
            }
            ConfigureViewData(item);
            return View(item);
        }

        // GET: [controller]/Delete/5
        [HttpGet("[controller]/Delete/{id}")]
        public ActionResult<TaskDTO> Delete(int id)
        {
            var item = _TaskService.Get(id).Data;
            if (item == null)
                return NotFound();
            return View(item);
        }

        //POST: [controller]/Delete/5
        [HttpPost("[controller]/Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult<TaskDTO> DeleteConfirmed(int id)
        {
            var item = _TaskService.Delete(id);
            if (item == null)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }

        protected void ConfigureViewData()
        {
            ViewData[TasksViewDataParams.EmpoyeeId] = new SelectList(
                _EmployeeService.GetAll().Data,
                nameof(EmployeeDTO.Id),
                nameof(Employee.Name));

            ViewData[TasksViewDataParams.DepartmentId] = new SelectList(_DepartmentService.GetAll().Data,
                nameof(DepartmentDTO.Id),
                nameof(DepartmentDTO.Name));
        }

        protected void ConfigureViewData(TaskDTO dto)
        {
            ViewData[TasksViewDataParams.EmpoyeeId] = new SelectList(
                _EmployeeService.GetAll().Data,
                nameof(EmployeeDTO.Id),
                nameof(Employee.Name), dto);

            ViewData[TasksViewDataParams.DepartmentId] = new SelectList(_DepartmentService.GetAll().Data,
                nameof(DepartmentDTO.Id),
                nameof(DepartmentDTO.Name), dto);
        }
    }
}
