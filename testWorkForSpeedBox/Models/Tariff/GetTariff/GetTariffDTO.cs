namespace testWorkForSpeedBox.Models.Tariff.GetTariff
{
    public class GetTariffDTO
    {
        public TariffCodes[] tariff_codes { get; set; }
        public Errors[] errors { get; set; }
    }
}