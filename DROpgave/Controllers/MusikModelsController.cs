using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibraryMusik;
using DROpgave;

namespace DROpgave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusikModelsController : ControllerBase
    {
        private readonly MusikContext _context;

        public MusikModelsController(MusikContext context)
        {
            _context = context;
        }

        // GET: api/MusikModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusikModel>>> GetMusiks()
        {
            return await _context.Musiks.ToListAsync();
        }

        // GET: api/MusikModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusikModel>> GetMusikModel(int id)
        {
            var musikModel = await _context.Musiks.FindAsync(id);

            if (musikModel == null)
            {
                return NotFound();
            }

            return musikModel;
        }

        // PUT: api/MusikModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusikModel(int id, MusikModel musikModel)
        {
            if (id != musikModel.id)
            {
                return BadRequest();
            }

            _context.Entry(musikModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusikModelExists(id))
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

        // POST: api/MusikModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MusikModel>> PostMusikModel(MusikModel musikModel)
        {
            _context.Musiks.Add(musikModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusikModel", new { id = musikModel.id }, musikModel);
        }

        // DELETE: api/MusikModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MusikModel>> DeleteMusikModel(int id)
        {
            var musikModel = await _context.Musiks.FindAsync(id);
            if (musikModel == null)
            {
                return NotFound();
            }

            _context.Musiks.Remove(musikModel);
            await _context.SaveChangesAsync();

            return musikModel;
        }

        private bool MusikModelExists(int id)
        {
            return _context.Musiks.Any(e => e.id == id);
        }
    }
}
