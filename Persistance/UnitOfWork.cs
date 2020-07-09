using System.Threading.Tasks;
using Vega.Core;
using Vega.Persistance.Repositories;

namespace Vega.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VegaDbContext context;

        public IVehicleRepository Vehicle { get; private set; }

        public UnitOfWork(VegaDbContext context)
        {
            this.context = context;
            Vehicle = new VehicleRepository(context);
        }

        public async Task Complete()
        {
            await context.SaveChangesAsync();
        }
    }
}
