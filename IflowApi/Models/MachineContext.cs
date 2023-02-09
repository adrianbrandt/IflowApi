using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace IflowApi.Models
{
    public class MachineContext : DbContext
    {
        public MachineContext(DbContextOptions<MachineContext> options)
            : base(options) 
        {  
        }

        public DbSet<Machine> Machines { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
