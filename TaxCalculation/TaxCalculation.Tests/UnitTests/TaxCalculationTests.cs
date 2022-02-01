using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Abstractions;
using TaxCalculation.Models.TaxJar;
using TaxCalculation.Services;
using TaxCalculation.Mappings;
using TaxCalculation.Models;

namespace TaxCalculation.Tests.UnitTests
{
    [TestClass]
    public class TaxCalculationTests
    {
        private readonly ITaxService _taxService;
        public TaxCalculationTests()
        {
            var taxConfig = new TaxServiceConfig();
            var taxJarApi = RestService.For<ITaxJarApi>(new HttpClient(new AuthHeaderHandler(taxConfig))
            {
                BaseAddress = new Uri(taxConfig.TaxJarBaseUrl)
            });
            var mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.AddProfile<TaxJarCalculationBodyMapping>();
                cfg.AddProfile<TaxJarCalculationResponseMapping>();
            }));
            _taxService = new TaxJarCalculator(taxJarApi, mapper);
        }

        [TestMethod]
        public void GetTaxCalculationForUSOrder()
        {
            try
            {
                var taxCalcRequest = new BasicTaxOnOrderRequest()
                {
                    FromCountry = "US",
                    FromZip = "07001",
                    FromState = "NJ",
                    ToCountry = "US",
                    ToZip = "07446",
                    ToState = "NJ",
                    Amount = 16.50,
                    Shipping = 1.5
                };
                var lineItems = new List<GenericLineItems>();
                lineItems.Add(new GenericLineItems
                {

                    Quantity = 1,
                    UnitPrice = 15.0,
                    TaxCode = "31000"
                });

                var expectedResult = new BasicTaxOnOrderResponse()
                {
                    AmountToCollect = 1.09,
                    OrderTotal = 16.5,
                    TaxRate = 0.06625,
                    Shipping = 1.5,
                    TaxSource = "destination",
                    TaxableAmount = 16.5
                };

                var taxJarResponse = _taxService.GetTaxOnOrder(taxCalcRequest, lineItems, new List<GenericNexusAddress>());
                foreach (var pi in expectedResult.GetType().GetProperties())
                {
                    Assert.AreEqual(pi.GetValue(expectedResult), pi.GetValue(taxJarResponse));
                }

            }
            catch(Exception ex)
            {
                var fuck = ex.Message;  
            }
           
        }
    }

        //[TestMethod]
        //public void GetTaxForNYProductExemption()
        //{

        //}

        //[TestMethod]
        //public void GetTaxForCAProductExemption()
        //{

        //}

        //[TestMethod]
        //public void GetTaxForCAOrder()
        //{

        //}

        //[TestMethod]
        //public void GetTaxForNoNexusOrder()
        //{

        //}

        //[TestMethod]
        //public void GetTaxForNexusOrder()
        //{

        //}

}
