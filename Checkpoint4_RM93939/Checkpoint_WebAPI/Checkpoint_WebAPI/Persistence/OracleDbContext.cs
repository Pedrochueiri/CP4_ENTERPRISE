using Checkpoint_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint_WebAPI.Persistence
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
        }

        public DbSet<Carros> Carros { get; set; }
    }
}
