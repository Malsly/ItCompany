using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Impl;
using Entities;

namespace ItCompany.Controllers
{
    public class EmployeeDepartmentsController : Controller
    {
        private readonly ItCompanyContext _context;

        public EmployeeDepartmentsController(ItCompanyContext context)
        {
            _context = context;
        }

        // GET: EmployeeDepartments
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeDepartment.ToListAsync());
        }

        // GET: EmployeeDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDepartment = await _context.EmployeeDepartment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDepartment == null)
            {
                return NotFound();
            }

            return View(employeeDepartment);
        }

        // GET: EmployeeDepartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] EmployeeDepartment employeeDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDepartment);
        }

        // GET: EmployeeDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDepartment = await _context.EmployeeDepartment.FindAsync(id);
            if (employeeDepartment == null)
            {
                return NotFound();
            }
            return View(employeeDepartment);
        }

        // POST: EmployeeDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] EmployeeDepartment employeeDepartment)
        {
            if (id != employeeDepartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDepartmentExists(employeeDepartment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDepartment);
        }

        // GET: EmployeeDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDepartment = await _context.EmployeeDepartment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDepartment == null)
            {
                return NotFound();
            }

            return View(employeeDepartment);
        }

        // POST: EmployeeDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDepartment = await _context.EmployeeDepartment.FindAsync(id);
            _context.EmployeeDepartment.Remove(employeeDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDepartmentExists(int id)
        {
            return _context.EmployeeDepartment.Any(e => e.Id == id);
        }
    }
}
