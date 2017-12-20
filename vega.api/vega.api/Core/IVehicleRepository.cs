using System.Collections.Generic;
using System.Threading.Tasks;
using vega.api.Core.Models;

namespace vega.api.Core
{
    public interface IVehicleRepository
    {
        Task<QueryResult<Vehicle>> GetVehicleAsync(VehicleQuery filter);

        Task<Vehicle> GetVehicleAsync(int id, bool includeRelated = true);

        void Add(Vehicle vehicle);

        void Remove(Vehicle vehicle);
    }
}