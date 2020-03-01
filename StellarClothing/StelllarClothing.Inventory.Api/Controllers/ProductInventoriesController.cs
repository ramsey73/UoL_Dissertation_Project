using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StelllarClothing.Inventory.Api.Domain;
using StelllarClothing.Inventory.Api.Infrastructure;

namespace StelllarClothing.Inventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInventoriesController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public ProductInventoriesController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInventory>>> GetProductInventories()
        {
            return await _context.ProductInventories.ToListAsync();
        }

        // GET: api/ProductInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductInventory>> GetProductInventory(int id)
        {
            var productInventory = await _context.ProductInventories.FindAsync(id);

            if (productInventory == null)
            {
                return NotFound();
            }

            return productInventory;
        }

        // PUT: api/ProductInventories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductInventory(int id, ProductInventory productInventory)
        {
            if (id != productInventory.Id)
            {
                return BadRequest();
            }

            _context.Entry(productInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductInventoryExists(id))
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

        // POST: api/ProductInventories
        [HttpPost]
        public async Task<ActionResult<ProductInventory>> PostProductInventory(ProductInventory productInventory)
        {
            _context.ProductInventories.Add(productInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductInventory", new { id = productInventory.Id }, productInventory);
        }

        // DELETE: api/ProductInventories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductInventory>> DeleteProductInventory(int id)
        {
            var productInventory = await _context.ProductInventories.FindAsync(id);
            if (productInventory == null)
            {
                return NotFound();
            }

            _context.ProductInventories.Remove(productInventory);
            await _context.SaveChangesAsync();

            return productInventory;
        }

        private bool ProductInventoryExists(int id)
        {
            return _context.ProductInventories.Any(e => e.Id == id);
        }
    }
}
