namespace testWorkForSpeedBox.Models.Tariff.GetTariff
{
    public class TariffCodes
    {
        public int tariff_code { get; set; }
        public string tariff_name { get; set; }
        public string tariff_description { get; set; }
        public int delivery_mode { get; set; }
        public float delivery_sum { get; set; }
        public int period_min { get; set; }
        public int period_max { get; set; }
        public int calendar_min { get; set; }
        public int calendar_max { get; set; }
    }
}
