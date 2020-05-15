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
    public class ItCompaniesController : Controller
    {
        private readonly ItCompanyContext _context;

        public ItCompaniesController(ItCompanyContext context)
        {
            _context = context;
        }

        // GET: ItCompanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItCompany.ToListAsync());
        }

        // GET: ItCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itCompany = await _context.ItCompany
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itCompany == null)
            {
                return NotFound();
            }

            return View(itCompany);
        }

        // GET: ItCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Entities.ItCompany itCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itCompany);
        }

        // GET: ItCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itCompany = await _context.ItCompany.FindAsync(id);
            if (itCompany == null)
            {
                return NotFound();
            }
            return View(itCompany);
        }

        // POST: ItCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Entities.ItCompany itCompany)
        {
            if (id != itCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItCompanyExists(itCompany.Id))
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
            return View(itCompany);
        }

        // GET: ItCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itCompany = await _context.ItCompany
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itCompany == null)
            {
                return NotFound();
            }

            return View(itCompany);
        }

        // POST: ItCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itCompany = await _context.ItCompany.FindAsync(id);
            _context.ItCompany.Remove(itCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItCompanyExists(int id)
        {
            return _context.ItCompany.Any(e => e.Id == id);
        }
    }
}
