using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StellarClothing.Admin.Api.Domain;
using StellarClothing.Admin.Api.Infrastructure;

namespace StellarClothing.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadingMenusController : ControllerBase
    {
        private readonly AdminContext _context;

        public HeadingMenusController(AdminContext context)
        {
            _context = context;
        }

        // GET: api/HeadingMenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeadingMenu>>> GetHeadingMenus()
        {
            return await _context.HeadingMenus.ToListAsync();
        }

        // GET: api/HeadingMenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeadingMenu>> GetHeadingMenu(int id)
        {
            var headingMenu = await _context.HeadingMenus.FindAsync(id);

            if (headingMenu == null)
            {
                return NotFound();
            }

            return headingMenu;
        }

        // PUT: api/HeadingMenus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeadingMenu(int id, HeadingMenu headingMenu)
        {
            if (id != headingMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(headingMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeadingMenuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HeadingMenus
        [HttpPost]
        public async Task<ActionResult<HeadingMenu>> PostHeadingMenu(HeadingMenu headingMenu)
        {
            _context.HeadingMenus.Add(headingMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeadingMenu", new { id = headingMenu.Id }, headingMenu);
        }

        // DELETE: api/HeadingMenus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HeadingMenu>> DeleteHeadingMenu(int id)
        {
            var headingMenu = await _context.HeadingMenus.FindAsync(id);
            if (headingMenu == null)
            {
                return NotFound();
            }

            _context.HeadingMenus.Remove(headingMenu);
            await _context.SaveChangesAsync();

            return headingMenu;
        }

        private bool HeadingMenuExists(int id)
        {
            return _context.HeadingMenus.Any(e => e.Id == id);
        }
    }
}
