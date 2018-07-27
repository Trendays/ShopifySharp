using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopifySharp
{
    public class RefundLineItem : ShopifyObject
    {
        /// <summary>
        /// The single <see cref="ShopifySharp.LineItem"/> being returned.
        /// </summary>
        [JsonProperty("line_item")]
        public LineItem LineItem { get; set; }

        /// <summary>
        /// The unique identifier of the refund line item.
        /// </summary>
        [JsonProperty("line_item_id")]
        public long? LineItemId { get; set; }

        /// <summary>
        /// The quantity of the associated line item that was returned.
        /// </summary>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Tax amount refunded
        /// </summary>
        [JsonProperty("total_tax")]
        public decimal? TotalTax { get; set; }

        /// <summary>
        /// Item subtotal
        /// </summary>
        [JsonProperty("subtotal")]
        public decimal? SubTotal { get; set; }

        /// <summary>
        /// How this refund line item affects inventory levels. Valid values: 
        /// no_restock: Refunding these items won't affect inventory. The number of fulfillable units for this line item will remain unchanged. For example, a refund payment can be issued but no items will be returned or made available for sale again.
        /// cancel: The items have not yet been fulfilled. The canceled quantity will be added back to the available count. The number of fulfillable units for this line item will decrease.
        /// return: The items were already delivered, and will be returned to the merchant. The returned quantity will be added back to the available count. The number of fulfillable units for this line item will remain unchanged.
        /// legacy_restock: The deprecated restock property was used for this refund. These items were made available for sale again. This value is not accepted when creating new refunds.
        /// </summary>
        [JsonProperty("restock_type")]
        public string RestockType { get; set; }

        /// <summary>
        /// he unique identifier of the location where the items will be restocked. Required when restock_type has the value return or cancel.
        /// </summary>
        [JsonProperty("location_id")]
        public long? LocationId { get; set; }
    }
}
