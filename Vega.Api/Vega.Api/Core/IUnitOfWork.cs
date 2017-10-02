using System.Threading.Tasks;

namespace Vega.Api.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
