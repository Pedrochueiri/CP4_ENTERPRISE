using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Checkpoint_WebAPI.Models;
using Checkpoint_WebAPI.Persistence;

namespace Checkpoint_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly OracleDbContext _context;

        public CarrosController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: api/Carros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carros>>> GetCarros()
        {
          if (_context.Carros == null)
          {
              return NotFound();
          }
            return await _context.Carros.ToListAsync();
        }

        // GET: api/Carros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carros>> GetCarros(int id)
        {
          if (_context.Carros == null)
          {
              return NotFound();
          }
            var carros = await _context.Carros.FindAsync(id);

            if (carros == null)
            {
                return NotFound();
            }

            return carros;
        }

        // PUT: api/Carros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarros(int id, Carros carros)
        {
            if (id != carros.Id)
            {
                return BadRequest();
            }

            _context.Entry(carros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrosExists(id))
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

        // POST: api/Carros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carros>> PostCarros(Carros carros)
        {
          if (_context.Carros == null)
          {
              return Problem("Entity set 'OracleDbContext.Carros'  is null.");
          }
            _context.Carros.Add(carros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarros", new { id = carros.Id }, carros);
        }

        // DELETE: api/Carros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarros(int id)
        {
            if (_context.Carros == null)
            {
                return NotFound();
            }
            var carros = await _context.Carros.FindAsync(id);
            if (carros == null)
            {
                return NotFound();
            }

            _context.Carros.Remove(carros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarrosExists(int id)
        {
            return (_context.Carros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
