using System.ComponentModel;

namespace testWorkForSpeedBox.Models.Main
{
    public class PriceCheck
    {
        public int Weight { get; set; }
        public SizeCheck size { get; set; }

        [DefaultValue("0c5b2444-70a0-4932-980c-b4dc0d3f02b5")]
        public Guid Sender { get; set; }
        [DefaultValue("0c5b2444-70a0-4932-980c-b4dc0d3f02b5")]
        public Guid Accepter { get; set; }
    }
}
