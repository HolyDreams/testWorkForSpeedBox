namespace testWorkForSpeedBox.Models.Tariff.SendTariff
{
    public class SendTariff
    {
        public LocationTariff from_location { get; set; }
        public LocationTariff to_location { get; set; }
        public PackageTariff[] packages { get; set; }
    }
}