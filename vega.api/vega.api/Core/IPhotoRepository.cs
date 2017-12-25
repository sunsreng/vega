using System.Collections.Generic;
using System.Threading.Tasks;
using vega.api.Core.Models;

namespace vega.api.Core
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetPhotos(int vehicleId);
    }
}