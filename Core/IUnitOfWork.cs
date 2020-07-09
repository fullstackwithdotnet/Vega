using System.Threading.Tasks;

namespace Vega.Core
{
    public interface IUnitOfWork
    {
        IVehicleRepository Vehicle { get; }

        Task Complete();
    }
}