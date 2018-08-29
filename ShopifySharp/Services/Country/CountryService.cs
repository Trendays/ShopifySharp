using ShopifySharp.Filters;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopifySharp
{
    public class CountryService : ShopifyService
    {
        public CountryService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken) { }

        /// <summary>
        /// Gets a count of all of the shop's countries.
        /// </summary>
        /// <returns>The count of all countries for the shop.</returns>
        public virtual async Task<int> CountAsync()
        {
            var req = PrepareRequest("countries/count.json");

            return await ExecuteRequestAsync<int>(req, HttpMethod.Get, rootElement: "count");
        }

        /// <summary>
        /// Gets a list of up to 250 of the shop's countries.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Country>> ListAsync(ListFilter filter = null)
        {
            var req = PrepareRequest("countries.json");

            if (filter != null)
            {
                req.QueryParams.AddRange(filter.ToParameters());
            }

            return await ExecuteRequestAsync<List<Country>>(req, HttpMethod.Get, rootElement: "countries");
        }

        /// <summary>
        /// Retrieves the <see cref="Country"/> with the given id.
        /// </summary>
        /// <param name="countryId">The id of the country to retrieve.</param>
        /// <param name="fields">A comma-separated list of fields to return.</param>
        /// <returns>The <see cref="Country"/>.</returns>
        public virtual async Task<Country> GetAsync(long countryId, string fields = null)
        {
            var req = PrepareRequest($"countries/{countryId}.json");

            if (string.IsNullOrEmpty(fields) == false)
            {
                req.QueryParams.Add("fields", fields);
            }

            return await ExecuteRequestAsync<Country>(req, HttpMethod.Get, rootElement: "country");
        }
    }
}
