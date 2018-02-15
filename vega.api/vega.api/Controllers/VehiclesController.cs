﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using vega.api.Controllers.Resources;
using vega.api.Core.Models;
using vega.api.Core;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace vega.api.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateVehicleAsync([FromBody] SaveVehicleResource vehicleResource)
        {
            //return BadRequest("bad request");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            repository.Add(vehicle);
            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicleAsync(vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateVehicleAsync(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await repository.GetVehicleAsync(id);

            if (vehicle == null)
                return NotFound();

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicleAsync(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteVehicleAsync(int id)
        {
            var vehicle = await repository.GetVehicleAsync(id, includeRelated: false);

            if (vehicle == null)
                return NotFound();

            repository.Remove(vehicle);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await repository.GetVehicleAsync(id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }

        [HttpGet]
        public async Task<QueryResultResource<VehicleResource>> GetVehicles(VehicleQueryResource filterResource)
        {
            var filter = mapper.Map<VehicleQueryResource, VehicleQuery>(filterResource);
            var queryResult = await repository.GetVehicleAsync(filter);

            return mapper.Map<QueryResult<Vehicle>, QueryResultResource<VehicleResource>>(queryResult);
        }
    }
}
