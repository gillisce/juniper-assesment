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
        
        //[Post("/api/document/create")]
        //[Headers("Authorization: Bearer", "Content-Type: application/json")]
        //public Task<HttpStatusCode> CreateDocument([Body] string docinfo);

    }
}
