using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.Core.Models;

namespace Vega.Core
{
    public interface IVehicleRepository
    {
        Task Add(Vehicle vehicle);
        Task<QueryResult<Vehicle>> GetAllVehicles(VehicleQuery filter);
        Task<Vehicle> GetVehicleById(int id, bool includeRelated = true);
        void Remove(Vehicle vehicle);
    }
}