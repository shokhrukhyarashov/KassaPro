using KassaPro.Data;
using KassaPro.DTOs;
using KassaPro.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KassaPro.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/brand")]
    public class BrandController : ControllerBase
    {
        private readonly PosContext _context;

        public BrandController(PosContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetIndex()
        {
            var brands = await _context.Brands
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return Ok(brands);
        }

        [HttpPost("store")]
        public async Task<IActionResult> PostStore([FromBody] BrandDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _context.Brands.AnyAsync(b => b.Name == dto.Name))
                return Conflict(new { message = "Brand already exists." });

            var brand = new Brand
            {
                Name = dto.Name,
                Image = dto.Image
            };

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Brand created successfully.", brand });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> PostUpdate(ulong id, [FromBody] BrandDto dto)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null) return NotFound();

            if (await _context.Brands.AnyAsync(b => b.Name == dto.Name && b.Id != id))
                return Conflict(new { message = "Another brand with this name already exists." });

            brand.Name = dto.Name;
            brand.Image = dto.Image ?? brand.Image;
            brand.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Brand updated successfully.", brand });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null) return NotFound();

            if (!string.IsNullOrEmpty(brand.Image))
                // FileHelper.DeleteFile("brand", brand.Image); // helper function

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Brand deleted successfully." });
        }
    }
}
