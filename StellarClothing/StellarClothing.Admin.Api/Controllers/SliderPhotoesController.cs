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
    public class SliderPhotoesController : ControllerBase
    {
        private readonly AdminContext _context;

        public SliderPhotoesController(AdminContext context)
        {
            _context = context;
        }

        // GET: api/SliderPhotoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SliderPhoto>>> GetSliderPhotos()
        {
            return await _context.SliderPhotos.ToListAsync();
        }

        // GET: api/SliderPhotoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SliderPhoto>> GetSliderPhoto(int id)
        {
            var sliderPhoto = await _context.SliderPhotos.FindAsync(id);

            if (sliderPhoto == null)
            {
                return NotFound();
            }

            return sliderPhoto;
        }

        // PUT: api/SliderPhotoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSliderPhoto(int id, SliderPhoto sliderPhoto)
        {
            if (id != sliderPhoto.Id)
            {
                return BadRequest();
            }

            _context.Entry(sliderPhoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SliderPhotoExists(id))
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

        // POST: api/SliderPhotoes
        [HttpPost]
        public async Task<ActionResult<SliderPhoto>> PostSliderPhoto(SliderPhoto sliderPhoto)
        {
            _context.SliderPhotos.Add(sliderPhoto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSliderPhoto", new { id = sliderPhoto.Id }, sliderPhoto);
        }

        // DELETE: api/SliderPhotoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SliderPhoto>> DeleteSliderPhoto(int id)
        {
            var sliderPhoto = await _context.SliderPhotos.FindAsync(id);
            if (sliderPhoto == null)
            {
                return NotFound();
            }

            _context.SliderPhotos.Remove(sliderPhoto);
            await _context.SaveChangesAsync();

            return sliderPhoto;
        }

        private bool SliderPhotoExists(int id)
        {
            return _context.SliderPhotos.Any(e => e.Id == id);
        }
    }
}
