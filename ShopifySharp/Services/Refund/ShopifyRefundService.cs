using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopifySharp
{
    public class ShopifyRefundService : ShopifyService
    {
        /// <summary>
        /// Creates a new instance of <see cref="ShopifyRefundService" />.
        /// </summary>
        /// <param name="myShopifyUrl">The shop's *.myshopify.com URL.</param>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public ShopifyRefundService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken) { }

        /// <summary>
        /// Creates a new <see cref="ShopifyRefund"/> on the store.
        /// </summary>
        /// <param name="order">A new <see cref="ShopifyRefund"/>. Id should be set to null.</param>
        /// <param name="options">Options for creating the order.</param>
        /// <returns>The new <see cref="ShopifyOrder"/>.</returns>
        public virtual async Task<ShopifyRefund> CreateAsync(long orderId, ShopifyRefund refund, ShopifyRefundCreateOptions options = null)
        {
            IRestRequest req = RequestEngine.CreateRequest($"orders/{orderId}/refunds.json", Method.POST, "refund");
            var body = refund.ToDictionary();

            if (options != null)
            {
                foreach (var kvp in options.ToDictionary())
                {
                    body.Add(kvp);
                }
            }

            //Build the request body
            req.AddJsonBody(new
            {
                refund = body
            });

            return await RequestEngine.ExecuteRequestAsync<ShopifyRefund>(_RestClient, req);
        }
    }
}
