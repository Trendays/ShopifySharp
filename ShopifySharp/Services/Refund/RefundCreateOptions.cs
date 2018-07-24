using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopifySharp
{
    public class RefundCreateOptions : Parameterizable
    {
        [JsonProperty("shipping")]
        public RefundShippingDto Shipping { get; set; }

        [JsonProperty("discrepancy_reason")]
        public string DiscrepancyReason { get; set; }
    }

    public class RefundShippingDto : Parameterizable
    {
        [JsonProperty("full_refund")]
        public bool? FullRefund { get; set; }

        [JsonProperty("amount")]
        public decimal? Amount { get; set; }
    }
}
