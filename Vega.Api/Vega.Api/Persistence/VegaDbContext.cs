using Microsoft.EntityFrameworkCore;
using Vega.Api.Models;

namespace Vega.Api.Persistence
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {

        }
        public DbSet<Make> Makes { get; set; }
    }
}
