using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Models.TaxJar;

namespace TaxCalculation.Abstractions
{
    public interface ITaxJarApi
    {
        //[Get("/rates/{zipCode}?country={country}&city={city}")]
        [QueryUriFormat(UriFormat.Unescaped)]
        [Get("/rates/{zipCode}{additionalParams}")]
        [Headers("Authorization: Token", "Content-Type: application/json")]
        public Task<TaxJarRateResponseObject> GetTaxRate(string zipCode, string additionalParams);

        [Post("/taxes")]
        [Headers("Authorization: Token", "Content-Type: application/json")]
        public Task<TaxOnOrderResponseObject> GetTaxOnOrder([Body]TaxJarBodyForOrder body);
        
        [Post("/taxes")]
        [Headers("Authorization: Token", "Content-Type: application/json")]
        public Task<ApiResponse<string>> GetTaxOnOrderV2(string body);
        //public Task<TaxOnOrderResponseObject> GetTaxOnOrder([Body] string body);

    }
}
