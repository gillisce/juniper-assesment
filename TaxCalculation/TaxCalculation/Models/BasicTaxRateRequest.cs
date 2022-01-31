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
        public double CountryRate { get; set; }
        public double StateRate { get; set; }
        public double CityRate { get; set; }
        public double CombinedDistrictRate { get; set; }
        public double CombinedRate { get; set; }
        public double DistanceSaleThreshold { get; set; }
        public double ParkingRate { get; set; }
        public double ReducedRate { get; set; }
        public double StandardRate { get; set; }
        public double SuperReducedRate { get; set; }
    }

}
