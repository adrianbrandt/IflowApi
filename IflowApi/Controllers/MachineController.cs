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
        public async Task<ActionResult<IEnumerable<Machine>>> GetMachines()
        {
            if (_dbContext.Machines== null)
            {
                return NotFound("Could not Find Machines");
            }
            return await _dbContext.Machines.ToListAsync();
        }
        
        //GET: api/Maskinene
        [HttpGet("{id},{key},{valid}")]
        public async Task<ActionResult<IEnumerable<Machine>>> GetUserMachines(int id, string key, int valid)
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
        public async Task<ActionResult<Machine>> GetMachine(int id)
        {
            if (_dbContext.Machines == null)
            {
                return NotFound("Could not Find Machines");
            }
  
            var machines = await _dbContext.Machines.FindAsync(id);

            if (machines == null)
            {
                return NotFound("Could not Find Machines");
            }
            return machines;
        }



        //POST: api/Maskiner
        [HttpPost("{navn},{user}")]
        public async Task<ActionResult<Machine>> PostMachine(string navn, int user)
        {
            Machine adder = new Machine();
            adder.user = user;
            adder.name = navn;
            _dbContext.Machines.Add(adder);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMachine), new { id = adder.id }, adder);
        }
        //PUT: api/maskin
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachine(int id, Machine maskin)
        {
            if (id != maskin.id)
            {
                return BadRequest("Could not Find Machine");
            }

            _dbContext.Entry(maskin).State = EntityState.Modified;

            try { await _dbContext.SaveChangesAsync();}
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
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
        public async Task<IActionResult> DeleteMachine(int id)
        {
            if (_dbContext.Machines == null)
            { 
                return NotFound("Could not Find Machines"); 
            }

            var machine = await _dbContext.Machines.FindAsync(id);
            if (machine == null)
            {
                return NotFound("Could not Find Machine");
            }
            _dbContext.Machines.Remove(machine);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        private bool MachineExists(long id)
        {
            return (_dbContext.Machines?.Any(e => e.id== id)).GetValueOrDefault();
        }


    }
}
