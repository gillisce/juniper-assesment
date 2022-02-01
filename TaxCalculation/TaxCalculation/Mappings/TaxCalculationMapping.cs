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
	public class TaxJarCalculationBodyMapping : Profile
	{
		public TaxJarCalculationBodyMapping()
		{
			CreateMap<BasicTaxOnOrderRequest, TaxJarBodyForOrder>()
				.ForMember(dest => dest.from_country, src => src.MapFrom(o => o.FromCountry))
				.ForMember(dest => dest.from_city, src => src.MapFrom(o => o.FromCity))
				.ForMember(dest => dest.from_state, src => src.MapFrom(o => o.FromState))
				.ForMember(dest => dest.from_street, src => src.MapFrom(o => o.FromStreet))
				.ForMember(dest => dest.from_zip, src => src.MapFrom(o => o.FromZip))
				.ForMember(dest => dest.to_country, src => src.MapFrom(o => o.ToCountry))
				.ForMember(dest => dest.to_city, src => src.MapFrom(o => o.ToCity))
				.ForMember(dest => dest.to_state, src => src.MapFrom(o => o.ToState))
				.ForMember(dest => dest.to_zip, src => src.MapFrom(o => o.ToZip))
				.ForMember(dest => dest.to_street, src => src.MapFrom(o => o.ToStreet))
				.ForMember(dest => dest.amount, src => src.MapFrom(o => o.Amount))
				.ForMember(dest => dest.shipping, src => src.MapFrom(o => o.Shipping))
				;
		}

	}

	public class TaxJarCalculationResponseMapping : Profile
	{
		public TaxJarCalculationResponseMapping()
        {
			CreateMap<TaxOnOrderResponseObject, BasicTaxOnOrderResponse>()
			.ForMember(dest => dest.AmountToCollect, src => src.MapFrom(o => o.tax.amount_to_collect))
			.ForMember(dest => dest.OrderTotal, src => src.MapFrom(o => o.tax.order_total_amount))
			.ForMember(dest => dest.Shipping, src => src.MapFrom(o => o.tax.shipping))
			.ForMember(dest => dest.TaxableAmount, src => src.MapFrom(o => o.tax.taxable_amount))
			.ForMember(dest => dest.TaxRate, src => src.MapFrom(o => o.tax.rate))
			.ForMember(dest => dest.TaxSource, src => src.MapFrom(o => o.tax.tax_source));


		}
	}
}
