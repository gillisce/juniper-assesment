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
        [Post("/v2/rates/{zipCode}?country={country}&city={city}")]
        [Headers("Authorization: Bearer", "Content-Type: application/json")]
        public Task<TaxRate> GetTaxRate(string zipCode, string country, string city);
        
        //[Post("/api/document/create")]
        //[Headers("Authorization: Bearer", "Content-Type: application/json")]
        //public Task<HttpStatusCode> CreateDocument([Body] string docinfo);

    }
}
