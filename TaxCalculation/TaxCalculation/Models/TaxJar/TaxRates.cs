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

    public class TaxJarRateResponseObject
	{
        public TaxJarRateResponse rate { get; set; }
    }

    public class TaxJarRateResponse
    {
        public string country { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string street { get; set; }

        public string country_rate { get; set; }
        public string state_rate { get; set; }
        public string city_rate { get; set; }
        public string combined_district_rate { get; set; }
        public string combined_rate { get; set; }
        public string distance_sale_threshold { get; set; }
        public string parking_rate { get; set; }
        public string reduced_rate { get; set; }
        public string standard_rate { get; set; }
        public string super_reduced_rate { get; set; }

        public bool freight_taxable { get; set; }

    }
}
