using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using vega.api.Models;
using vega.api.Persistence;

namespace vega.api.Controllers
{
    public class MakesController: Controller
    {
        private readonly VegaDbContext context;
        public MakesController(VegaDbContext context)
        {
            this.context = context;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<Make>> GetMakesAsync()
        {
            return await context.Makes.Include(m => m.Models).ToListAsync();
        }
    }
}
