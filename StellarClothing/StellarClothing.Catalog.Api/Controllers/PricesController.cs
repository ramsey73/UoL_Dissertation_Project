﻿using System;
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
    public class PricesController : ControllerBase
    {
        private readonly CatalogDbContext _context;

        public PricesController(CatalogDbContext context)
        {
            _context = context;
        }

        // GET: api/Prices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Price>>> GetPrices()
        {
            return await _context.Prices.ToListAsync();
        }

        // GET: api/Prices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Price>> GetPrice(long id)
        {
            var price = await _context.Prices.FindAsync(id);

            if (price == null)
            {
                return NotFound();
            }

            return price;
        }

        // PUT: api/Prices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrice(long id, Price price)
        {
            if (id != price.Id)
            {
                return BadRequest();
            }

            _context.Entry(price).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceExists(id))
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

        // POST: api/Prices
        [HttpPost]
        public async Task<ActionResult<Price>> PostPrice(Price price)
        {
            _context.Prices.Add(price);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrice", new { id = price.Id }, price);
        }

        // DELETE: api/Prices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Price>> DeletePrice(long id)
        {
            var price = await _context.Prices.FindAsync(id);
            if (price == null)
            {
                return NotFound();
            }

            _context.Prices.Remove(price);
            await _context.SaveChangesAsync();

            return price;
        }

        private bool PriceExists(long id)
        {
            return _context.Prices.Any(e => e.Id == id);
        }
    }
}
