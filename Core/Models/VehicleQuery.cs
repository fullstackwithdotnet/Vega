using Vega.Extentions;

namespace Vega.Core.Models {
    public class VehicleQuery : IQueryObject {
        public int? MakeId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAssending { get; set;}
        public int Page { get; set; }
        public byte PageSize { get; set; }
        
    }

}