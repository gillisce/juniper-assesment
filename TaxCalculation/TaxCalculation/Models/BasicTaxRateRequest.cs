using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculation.Models
{
    //For now these look pretty similar to TaxJar objects
    //In theory these could change and become more/less complex as we add mulitple services that will share this
    public class BasicTaxRateRequest
    {
        public string Country { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }

    public class TaxRateObject
    {
        public decimal? CountryRate { get; set; }
        public decimal? StateRate { get; set; }
        public decimal? CityRate { get; set; }
        public decimal? CombinedDistrictRate { get; set; }
        public decimal? CominedRate { get; set; }
    }

}
