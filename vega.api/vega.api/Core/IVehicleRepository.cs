﻿using System.Collections.Generic;
using System.Threading.Tasks;
using vega.api.Core.Models;

namespace vega.api.Core
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetVehicleAsync();

        Task<Vehicle> GetVehicleAsync(int id, bool includeRelated = true);

        void Add(Vehicle vehicle);

        void Remove(Vehicle vehicle);
    }
}