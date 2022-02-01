using AutoMapper;
using Newtonsoft.Json;
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
                //Allows us the flexibilty for the data to be as specific or generic as needed for the api call
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

        public async Task<BasicTaxOnOrderResponse> GetTaxOnOrder(BasicTaxOnOrderRequest _input, List<GenericLineItems> _orderLineItems, List<GenericNexusAddress> _extraAdresses)
		{
			try
			{
                var taxJarRequestObject = _mapper.Map<TaxJarBodyForOrder>(_input);
                if (_orderLineItems.Any() && _orderLineItems.Count > 0)
                {
                    _orderLineItems.ForEach(ol =>
                    {
                        taxJarRequestObject.line_items.Add(new LineItems()
                        {
                            product_tax_code = ol.TaxCode,
                            quantity = ol.Quantity,
                            unit_price = ol.UnitPrice
                        });
                    });
                }

                //if (_extraAdresses.Any() && _extraAdresses.Count > 0)
                //{
                //    _extraAdresses.ForEach(ea =>
                //    {
                //        taxJarRequestObject.nexus_addresses.Add(new NexusAddress()
                //        {
                //            country = ea.Country,
                //            state = ea.State,
                //            zip = ea.Zip
                //        });
                //    });
                //}

                //Refit interface call to the External API
                var serial = JsonConvert.SerializeObject(taxJarRequestObject);
                 var response = await _taxJar.GetTaxOnOrderV2(serial);
                //var response = await _taxJar.GetTaxOnOrder(JsonConvert.SerializeObject(taxJarRequestObject));
                return _mapper.Map<BasicTaxOnOrderResponse>(response);

			}catch(Exception ex)
            {
                var e = ex.Message;
                return new BasicTaxOnOrderResponse();
            }
		}

    }
}
