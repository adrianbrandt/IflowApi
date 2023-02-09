using IflowApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IflowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]

    public class MachineController : ControllerBase
    {
        private readonly MachineContext _dbContext;


        public MachineController(MachineContext dbContext)
        {
            _dbContext = dbContext;
        }


        //GET: api/Maskiner
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Machine>>> GetMaskiner()
        {
            if (_dbContext.Machines== null)
            {
                return NotFound("Could not Find Machines");
            }
            return await _dbContext.Machines.ToListAsync();
        }
        
        //GET: api/Maskinene
        [HttpGet("{id},{key},{valid}")]
        public async Task<ActionResult<IEnumerable<Machine>>> GetMaskinene(int id, string key, int valid)
        {
            var usr = await _dbContext.Users.FindAsync(id);

            if (usr == null)
            {
                return NotFound("No User Found");
            }
            if (valid != 1) { return NotFound(); }
            if (key != "all") { return NotFound(); }

            if (_dbContext.Machines == null)
            {
                return NotFound("Could not Find Machines");
            }

            var test = _dbContext.Machines.Where(x => x.user == usr.id).ToListAsync();
            return await test;

        }
        

        //GET: api/Maskiner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Machine>> GetMaskin(int id)
        {
            if (_dbContext.Machines == null)
            {
                return NotFound("Could not Find Machines");
            }
  
            var maskiner = await _dbContext.Machines.FindAsync(id);

            if (maskiner == null)
            {
                return NotFound("Could not Find Machines");
            }
            return maskiner;
        }



        //POST: api/Maskiner
        [HttpPost("{navn},{user}")]
        public async Task<ActionResult<Machine>> PostMaskin(string navn, int user)
        {
            Machine leggtil = new Machine();
            leggtil.user = user;
            leggtil.name = navn;
            _dbContext.Machines.Add(leggtil);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMaskin), new { id = leggtil.id }, leggtil);
        }
        //PUT: api/maskin
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaskin(int id, Machine maskin)
        {
            if (id != maskin.id)
            {
                return BadRequest("Could not Find Machine");
            }

            _dbContext.Entry(maskin).State = EntityState.Modified;

            try { await _dbContext.SaveChangesAsync();}
            catch (DbUpdateConcurrencyException)
            {
                if (!MaskinExists(id))
                {
                    return NotFound("Could not Find Machine");
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //DELETE: api/Maskin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaskin(int id)
        {
            if (_dbContext.Machines == null)
            { 
                return NotFound("Could not Find Machines"); 
            }

            var maskin = await _dbContext.Machines.FindAsync(id);
            if (maskin == null)
            {
                return NotFound("Could not Find Machine");
            }
            _dbContext.Machines.Remove(maskin);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        private bool MaskinExists(long id)
        {
            return (_dbContext.Machines?.Any(e => e.id== id)).GetValueOrDefault();
        }


    }
}
