using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Abstractions;
using TaxCalculation.Models;
using TaxCalculation.Models.TaxJar;
using static System.Net.WebRequestMethods;

namespace TaxCalculation.Services
{
    public class TaxJarCalculator : ITaxService
    {

        private readonly ITaxJarApi _taxJar;
        private readonly IMapper _mapper;

        public TaxJarCalculator(ITaxJarApi taxJarApi, IMapper mapper)
        {
            _taxJar = taxJarApi;
            _mapper = mapper;
        }


        public async Task<TaxRateObject> GetTaxRateByLocation(BasicTaxRateRequest _input)
		{
			try
			{
                var taxJarRequestObject = _mapper.Map<TaxRate>(_input);

                var extraQueryBuilder = "?";
                extraQueryBuilder += !string.IsNullOrEmpty(taxJarRequestObject.Country) ? $"country={taxJarRequestObject.Country}&" : "";
                extraQueryBuilder += !string.IsNullOrEmpty(taxJarRequestObject.City) ? $"city={taxJarRequestObject.City}&" : "";
                extraQueryBuilder += !string.IsNullOrEmpty(taxJarRequestObject.Street) ? $"state={taxJarRequestObject.State}&" : "";
                extraQueryBuilder += !string.IsNullOrEmpty(taxJarRequestObject.Street) ? $"street={taxJarRequestObject.Street}&" : "";

                //Refit way to call the API Endpoint of tax jar
                var response = await _taxJar.GetTaxRate(taxJarRequestObject.Zip, extraQueryBuilder);
               
                return _mapper.Map<TaxRateObject>(response);
            }
            catch(Exception ex)
			{
                var e = ex.Message;
                return new TaxRateObject();
			}
           
        }



    }
}
