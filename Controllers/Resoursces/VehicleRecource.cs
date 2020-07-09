using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.Controllers.Resoursces
{
    public class VehicleRecource
    {
        public int Id { get; set; }
        public KeyValuePairResource Make { get; set; }
        public KeyValuePairResource Model { get; set; }

        public bool IsRegistered { get; set; }

        public ContactResource Contact { get; set; }

        public ICollection<KeyValuePairResource> Features { get; set; }

        public VehicleRecource()
        {
            Features = new Collection<KeyValuePairResource>();
        }
    }
}
