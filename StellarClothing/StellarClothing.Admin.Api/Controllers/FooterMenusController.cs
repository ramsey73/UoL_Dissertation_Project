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
    public class FooterMenusController : ControllerBase
    {
        private readonly AdminContext _context;

        public FooterMenusController(AdminContext context)
        {
            _context = context;
        }

        // GET: api/FooterMenus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FooterMenu>>> GetFooterMenus()
        {
            return await _context.FooterMenus.ToListAsync();
        }

        // GET: api/FooterMenus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FooterMenu>> GetFooterMenu(int id)
        {
            var footerMenu = await _context.FooterMenus.FindAsync(id);

            if (footerMenu == null)
            {
                return NotFound();
            }

            return footerMenu;
        }

        // PUT: api/FooterMenus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFooterMenu(int id, FooterMenu footerMenu)
        {
            if (id != footerMenu.Id)
            {
                return BadRequest();
            }

            _context.Entry(footerMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FooterMenuExists(id))
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

        // POST: api/FooterMenus
        [HttpPost]
        public async Task<ActionResult<FooterMenu>> PostFooterMenu(FooterMenu footerMenu)
        {
            _context.FooterMenus.Add(footerMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFooterMenu", new { id = footerMenu.Id }, footerMenu);
        }

        // DELETE: api/FooterMenus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FooterMenu>> DeleteFooterMenu(int id)
        {
            var footerMenu = await _context.FooterMenus.FindAsync(id);
            if (footerMenu == null)
            {
                return NotFound();
            }

            _context.FooterMenus.Remove(footerMenu);
            await _context.SaveChangesAsync();

            return footerMenu;
        }

        private bool FooterMenuExists(int id)
        {
            return _context.FooterMenus.Any(e => e.Id == id);
        }
    }
}
