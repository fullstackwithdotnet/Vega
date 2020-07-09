using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Controllers.Resoursces;
using Vega.Core;
using Vega.Core.Models;

namespace Vega.Controllers {
    [Route ("api/vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VehicleController (IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<QueryResultResource<VehicleRecource>> GetVehicles ([FromQuery] VehicleQueryResource filterResource) {
            var filter = mapper.Map<VehicleQueryResource, VehicleQuery> (filterResource);
            var queryResult = await unitOfWork.Vehicle.GetAllVehicles (filter);

            return mapper.Map<QueryResult<Vehicle>, QueryResultResource<VehicleRecource>> (queryResult);

        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetVehicle (int id) {
            Vehicle vehicle = await unitOfWork.Vehicle.GetVehicleById (id);

            if (vehicle == null)
                return NotFound ();

            var result = mapper.Map<Vehicle, VehicleRecource> (vehicle);

            return Ok (result);

        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle ([FromBody] SaveVehicleRecource vehicleRecource) {

            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            var vehicle = mapper.Map<SaveVehicleRecource, Vehicle> (vehicleRecource);

            await unitOfWork.Vehicle.Add (vehicle);

            await unitOfWork.Complete ();

            vehicle = await unitOfWork.Vehicle.GetVehicleById (vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleRecource> (vehicle);
            return Ok (result);
        }

        [HttpPut ("{id}")] //api/vehicles/id
        public async Task<IActionResult> UpdateVehicle (int id, [FromBody] SaveVehicleRecource vehicleRecource) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            var vehicle = await unitOfWork.Vehicle.GetVehicleById (id);

            mapper.Map<SaveVehicleRecource, Vehicle> (vehicleRecource, vehicle);

            await unitOfWork.Complete ();

            var result = mapper.Map<Vehicle, SaveVehicleRecource> (vehicle);
            return Ok (result);
        }

        [HttpDelete ("{id}")] //api/vehicles/id
        public async Task<IActionResult> DeleteVehicle (int id) {

            var vehicle = await unitOfWork.Vehicle.GetVehicleById (id, includeRelated : false);

            if (vehicle == null)
                return NotFound ();

            unitOfWork.Vehicle.Remove (vehicle);

            await unitOfWork.Complete ();

            return Ok (vehicle);
        }

    }
}