using System.Threading.Tasks;

namespace vega.api.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
