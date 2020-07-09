using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Core;
using Vega.Core.Models;
using Vega.Extentions;

namespace Vega.Persistance.Repositories {
    public class VehicleRepository : IVehicleRepository {
        private readonly VegaDbContext context;

        public VehicleRepository (VegaDbContext context) {
            this.context = context;
        }
        public async Task<QueryResult<Vehicle>> GetAllVehicles (VehicleQuery queryObject) {
            var result =  new QueryResult<Vehicle>();
           
            var query = context.Vehicles
                .Include (v => v.Features)
                .ThenInclude (vf => vf.Feature)
                .Include (m => m.Model)
                .ThenInclude (m => m.Make)
                .AsQueryable ();

            if (queryObject.MakeId.HasValue) {
                query = query.Where (v => v.Model.MakeId == queryObject.MakeId.Value);
            }

            var columnsMap = new Dictionary<string, Expression<Func<Vehicle, object>>>()
            {
                ["make"] = v => v.Model.Make.Name,
                ["model"] = v => v.Model.Name,
                ["contactName"] = v => v.ContactName
            };

            query = query.ApplyOdering(queryObject, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObject);

            result.Items = await query.ToListAsync();
        
            return result; 
        }

        
        public async Task<Vehicle> GetVehicleById (int id, bool includeRelated = true) {
            if (!includeRelated)
                return await context.Vehicles.FindAsync (id);

            return await context.Vehicles
                .Include (v => v.Features)
                .ThenInclude (vf => vf.Feature)
                .Include (m => m.Model)
                .ThenInclude (mk => mk.Make)
                .SingleOrDefaultAsync (v => v.Id == id);

        }

        public async Task Add (Vehicle vehicle) {
            await context.Vehicles.AddAsync (vehicle);
        }

        public void Remove (Vehicle vehicle) {
            context.Vehicles.Remove (vehicle);
        }
    }
}