using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StellarClothing.Catalog.Domain;
using StellarClothing.Catalog.Infrastructure;

namespace StellarClothing.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPhotoesController : ControllerBase
    {
        private readonly CatalogDbContext _context;

        public ProductPhotoesController(CatalogDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductPhotoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPhoto>>> GetProductPhotos()
        {
            return await _context.ProductPhotos.ToListAsync();
        }

        // GET: api/ProductPhotoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductPhoto>> GetProductPhoto(int id)
        {
            var productPhoto = await _context.ProductPhotos.FindAsync(id);

            if (productPhoto == null)
            {
                return NotFound();
            }

            return productPhoto;
        }

        // PUT: api/ProductPhotoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductPhoto(int id, ProductPhoto productPhoto)
        {
            if (id != productPhoto.Id)
            {
                return BadRequest();
            }

            _context.Entry(productPhoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPhotoExists(id))
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

        // POST: api/ProductPhotoes
        [HttpPost]
        public async Task<ActionResult<ProductPhoto>> PostProductPhoto(ProductPhoto productPhoto)
        {
            _context.ProductPhotos.Add(productPhoto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductPhoto", new { id = productPhoto.Id }, productPhoto);
        }

        // DELETE: api/ProductPhotoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductPhoto>> DeleteProductPhoto(int id)
        {
            var productPhoto = await _context.ProductPhotos.FindAsync(id);
            if (productPhoto == null)
            {
                return NotFound();
            }

            _context.ProductPhotos.Remove(productPhoto);
            await _context.SaveChangesAsync();

            return productPhoto;
        }

        private bool ProductPhotoExists(int id)
        {
            return _context.ProductPhotos.Any(e => e.Id == id);
        }
    }
}
