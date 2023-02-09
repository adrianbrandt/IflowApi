using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IflowApi.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.AspNetCore.Cors;

namespace IflowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class UserController : ControllerBase
    {
        private readonly MachineContext _context;

        public UserController(MachineContext context)
        {
            _context = context;
        }


        // GET: api/Brukereres/5
        [HttpGet("{id},{pass}")]
        public async Task<ActionResult<User>> GetBruker(int id, string pass)
        {   
            var bruker = await _context.Users.FindAsync(id);

            if (bruker == null)
            {
                return NotFound("Could not Find User");
            }

            if (bruker.passord != pass)
            {
                return BadRequest("Password Mismatch");
            }



            return bruker;
        }



        // GET: api/Brukers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetBrukere()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Brukers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetBruker(int id)
        {
            var bruker = await _context.Users.FindAsync(id);

            if (bruker == null)
            {
                return NotFound("No User Found");
            }

            return bruker;
        }

        // PUT: api/Brukers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBruker(int id, User bruker)
        {
            if (id != bruker.id)
            {
                return BadRequest();
            }

            _context.Entry(bruker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrukerExists(id))
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

        // POST: api/Brukers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostBruker(User bruker)
        {
            _context.Users.Add(bruker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBruker", new { id = bruker.id }, bruker);
        }

        // DELETE: api/Brukers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBruker(int id)
        {
            var bruker = await _context.Users.FindAsync(id);
            if (bruker == null)
            {
                return NotFound();
            }

            _context.Users.Remove(bruker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrukerExists(int id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}
