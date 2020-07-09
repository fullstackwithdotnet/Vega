namespace Vega.Controllers.Resoursces {
    public class VehicleQueryResource {
        public int? MakeId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAssending { get; set; }

        public int Page { get; set; }
        public byte PageSize { get; set; }

    }
}