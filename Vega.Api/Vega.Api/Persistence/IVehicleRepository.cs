using System.Threading.Tasks;
using Vega.Api.Models;

namespace Vega.Api.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleAsync(int id);
    }
}