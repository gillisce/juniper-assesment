using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Models;
using TaxCalculation.Models.TaxJar;

namespace TaxCalculation.Mappings
{
    public class TaxJarRateMapping : Profile
    {
        public TaxJarRateMapping()
        {
            CreateMap<BasicTaxRateRequest, TaxRate>();

        }

    }
}
