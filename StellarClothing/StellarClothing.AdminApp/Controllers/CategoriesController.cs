using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StellarClothing.Web.Common.Models;

namespace StellarClothing.AdminApp.Controllers
{
    public class CategoriesController : Controller
    {

        public CategoriesController()
        {
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            throw new NotImplementedException();
            //return View(await _context.Categories.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var category = await _context.Categories
            //    .FirstOrDefaultAsync(m => m.Category_id == id);
            //if (category == null)
            //{
            //    return NotFound();
            //}

            //return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Category_id,Name")] Category category)
        {
            throw new NotImplementedException();
            //if (ModelState.IsValid)
            //{
            //    _context.Add(category);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var category = await _context.Categories.FindAsync(id);
            //if (category == null)
            //{
            //    return NotFound();
            //}
            //return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Category_id,Name")] Category category)
        {
            throw new NotImplementedException();
            //if (id != category.Category_id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(category);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!CategoryExists(category.Category_id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var category = await _context.Categories
            //    .FirstOrDefaultAsync(m => m.Category_id == id);
            //if (category == null)
            //{
            //    return NotFound();
            //}

            //return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            throw new NotImplementedException();
            //var category = await _context.Categories.FindAsync(id);
            //_context.Categories.Remove(category);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(byte id)
        {
            throw new NotImplementedException();
            //return _context.Categories.Any(e => e.Category_id == id);
        }
    }
}