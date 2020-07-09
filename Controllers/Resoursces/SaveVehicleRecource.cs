using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.Controllers.Resoursces
{
    public class SaveVehicleRecource
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

        public ContactResource Contact { get; set; }

        public ICollection<int> Features { get; set; }

        public SaveVehicleRecource()
        {
            Features = new Collection<int>();
        }
    }
}
