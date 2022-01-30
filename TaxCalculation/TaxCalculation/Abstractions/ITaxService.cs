using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Models;

namespace TaxCalculation.Abstractions
{
   public  interface ITaxService
    {
        //Get Tax Rate for Location
        Task<TaxRateObject> GetTaxRateByLocation(BasicTaxRateRequest Input);

        //Calculate Taxes For Order
    }
}
