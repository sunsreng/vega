using Microsoft.EntityFrameworkCore;
using vega.api.Models;

namespace vega.api.Persistence
{
    public class VegaDbContext: DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options): base(options)
        {

        }

        public DbSet<Make> Makes { get; set; }
    }
}
