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

    public class TaxJarRateResponseMapping : Profile
    { 
        public TaxJarRateResponseMapping()
        {

            CreateMap<TaxRateResponse, TaxRateObject>()
                 .ForMember(dest => dest.CityRate, src => src.MapFrom(o => decimal.Parse(o.CityRate, 0)))
                 .ForMember(dest => dest.CountryRate, src => src.MapFrom(o => decimal.Parse(o.CountryRate, 0)))
                 .ForMember(dest => dest.StateRate, src => src.MapFrom(o => decimal.Parse(o.StateRate, 0)))
                 .ForMember(dest => dest.CombinedDistrictRate, src => src.MapFrom(o => decimal.Parse(o.CombinedDistrictRate, 0)))
                 .ForMember(dest => dest.CominedRate, src => src.MapFrom(o => decimal.Parse(o.CominedRate, 0)));        }

    }

}
