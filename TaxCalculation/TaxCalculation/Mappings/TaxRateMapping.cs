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

            CreateMap<TaxJarRateResponseObject, TaxRateObject>()
                 .ForMember(dest => dest.CityRate, src => src.MapFrom(o => Convert.ToDouble(o.rate.city_rate)))
                 .ForMember(dest => dest.CountryRate, src => src.MapFrom(o => Convert.ToDouble(o.rate.country_rate)))
                 .ForMember(dest => dest.StateRate, src => src.MapFrom(o => Convert.ToDouble(o.rate.state_rate)))
                 .ForMember(dest => dest.CombinedDistrictRate, src => src.MapFrom(o => Convert.ToDouble(o.rate.combined_district_rate)))
                 .ForMember(dest => dest.CombinedRate, src => src.MapFrom(o => Convert.ToDouble(o.rate.combined_rate)))
                 .ForMember(dest => dest.DistanceSaleThreshold, src => src.MapFrom(o => Convert.ToDouble(o.rate.distance_sale_threshold)))
                 .ForMember(dest => dest.ParkingRate, src => src.MapFrom(o => Convert.ToDouble(o.rate.parking_rate)))
                 .ForMember(dest => dest.ReducedRate, src => src.MapFrom(o => Convert.ToDouble(o.rate.reduced_rate)))
                 .ForMember(dest => dest.StandardRate, src => src.MapFrom(o => Convert.ToDouble(o.rate.standard_rate)))
                 .ForMember(dest => dest.SuperReducedRate, src => src.MapFrom(o => Convert.ToDouble(o.rate.super_reduced_rate)));        
        }

    }

}
