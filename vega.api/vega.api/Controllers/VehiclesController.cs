using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using vega.api.Controllers.Resources;
using vega.api.Models;
using vega.api.Persistence;

namespace vega.api.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;

        public VehiclesController(IMapper mapper, VegaDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicleAsync([FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
    }
}
