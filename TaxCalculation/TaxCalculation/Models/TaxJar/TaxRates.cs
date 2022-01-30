using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculation.Models.TaxJar
{
    public class TaxRate
    {
        public string Country { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

    }

    public class TaxRateResponse
    {
        public string Country { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public string CountryRate { get; set; }
        public string StateRate { get; set; }
        public string CityRate { get; set; }
        public string CombinedDistrictRate { get; set; }
        public string CominedRate { get; set; }
        public bool FreightTaxable { get; set; }
    }
}
