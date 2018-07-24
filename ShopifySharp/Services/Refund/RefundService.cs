using ShopifySharp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopifySharp
{
    public class RefundService : ShopifyService
    {
        /// <summary>
        /// Creates a new instance of <see cref="RefundService" />.
        /// </summary>
        /// <param name="myShopifyUrl">The shop's *.myshopify.com URL.</param>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public RefundService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken) { }

        /// <summary>
        /// Creates a new <see cref="ShopifyRefund"/> on the store.
        /// </summary>
        /// <param name="order">A new <see cref="ShopifyRefund"/>. Id should be set to null.</param>
        /// <param name="options">Options for creating the order.</param>
        /// <returns>The new <see cref="ShopifyOrder"/>.</returns>
        public virtual async Task<Refund> CreateAsync(long orderId, Refund refund, RefundCreateOptions options = null)
        {
            var req = PrepareRequest($"orders/{orderId}/refunds.json");
            var body = refund.ToDictionary();

            if (options != null)
            {
                foreach (var kvp in options.ToDictionary())
                {
                    body.Add(kvp);
                }
            }

            //Build the request body
            var content = new JsonContent(new
            {
                refund = body
            });

            return await ExecuteRequestAsync<Refund>(req, HttpMethod.Post, content, "refund");
        }
    }
}
