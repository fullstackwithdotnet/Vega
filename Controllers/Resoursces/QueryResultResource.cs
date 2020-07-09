using System.Collections.Generic;

namespace Vega.Controllers.Resoursces {
    public class QueryResultResource<T> {

        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
    }

}