using testWorkForSpeedBox.Models.Tariff;

namespace testWorkForSpeedBox.Models
{
    public class GetAddressFromFiasDTO
    {
        public int code { get; set; }
        public string city { get; set; }
        public Guid? fias_guid { get; set; }
        public Guid city_uuid { get; set; }
        public string? kladr_code { get; set; }
        public string country_code { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public int? region_code { get; set; }
        public Guid? fias_region_guid { get; set; }
        public string? kladr_region_code { get; set; }
        public string? sub_region { get; set; }
        public float? longitude { get; set; }
        public float? latitude { get; set; }
        public string? time_zode { get; set; }
        public float payment_limit { get; set; }
        public Errors[] errors { get; set; }
    }
}
