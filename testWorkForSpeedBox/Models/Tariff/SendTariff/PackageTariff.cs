namespace testWorkForSpeedBox.Models.Tariff.SendTariff
{
    public class PackageTariff
    {
        public int weight { get; set; }
        public int? length { get; set; } = null;
        public int? width { get; set; } = null;
        public int? height { get; set; } = null;
    }
}