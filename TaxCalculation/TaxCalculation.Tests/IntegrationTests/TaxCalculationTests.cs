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

namespace TaxCalculation.Tests.IntegrationTests
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

            var taxJarResponse = _taxService.GetTaxOnOrder(taxCalcRequest, lineItems, new List<GenericNexusAddress>()).Result;
            foreach (var pi in expectedResult.GetType().GetProperties())
            {
                Assert.AreEqual(pi.GetValue(expectedResult), pi.GetValue(taxJarResponse));
            }
        }
        [TestMethod]
        public void GetTaxForNYProductExemption()
        {
            var taxCalcRequest = new BasicTaxOnOrderRequest()
            {
                FromCountry = "US",
                FromCity = "Delmar",
                FromZip = "12054",
                FromState = "NY",
                ToCountry = "US",
                ToCity = "Mahopac",
                ToZip = "10541",
                ToState = "NY",
                Amount = 29.94,
                Shipping = 7.99
            };
            var lineItems = new List<GenericLineItems>();
            lineItems.Add(new GenericLineItems
            {

                Quantity = 1,
                UnitPrice = 19.99,
                TaxCode = "20010"
            }); 
            lineItems.Add(new GenericLineItems
            {

                Quantity = 1,
                UnitPrice = 9.95,
                TaxCode = "20010"
            });

            var expectedResult = new BasicTaxOnOrderResponse()
            {
                AmountToCollect = 1.98,
                OrderTotal = 37.93,
                TaxRate = 0.05218,
                Shipping = 7.99,
                TaxSource = "destination",
                TaxableAmount = 37.93
            };

            var taxJarResponse = _taxService.GetTaxOnOrder(taxCalcRequest, lineItems, new List<GenericNexusAddress>()).Result;
            foreach (var pi in expectedResult.GetType().GetProperties())
            {
                Assert.AreEqual(pi.GetValue(expectedResult), pi.GetValue(taxJarResponse));
            }
        }

        [TestMethod]
        public void GetTaxForNexusOrder()
        {
            var taxCalcRequest = new BasicTaxOnOrderRequest()
            {
                FromCountry = "US",
                FromCity = "Orlando",
                FromZip = "32801",
                FromState = "FL",
                ToCountry = "US",
                ToCity = "Kansas City",
                ToZip = "64155",
                ToState = "MO",
                Amount = 29.94,
                Shipping = 7.99
            };
            var lineItems = new List<GenericLineItems>();
            lineItems.Add(new GenericLineItems
            {

                Quantity = 1,
                UnitPrice = 19.99,
            });
            lineItems.Add(new GenericLineItems
            {

                Quantity = 1,
                UnitPrice = 9.95,
            });
            var genAddress = new List<GenericNexusAddress>();
            genAddress.Add(new GenericNexusAddress()
            {
                Country = "US",
                State = "FL",
                Zip = "32801"
            });  
            genAddress.Add(new GenericNexusAddress()
            {
                Country = "US",
                State = "MO",
                Zip = "63101"
            });

            var expectedResult = new BasicTaxOnOrderResponse()
            {
                AmountToCollect = 2.9,
                OrderTotal = 37.93,
                TaxRate = 0.09679,
                Shipping = 7.99,
                TaxSource = "origin",
                TaxableAmount = 29.94
            };

            var taxJarResponse = _taxService.GetTaxOnOrder(taxCalcRequest, lineItems, genAddress).Result;
            foreach (var pi in expectedResult.GetType().GetProperties())
            {
                Assert.AreEqual(pi.GetValue(expectedResult), pi.GetValue(taxJarResponse));
            }
        }


        //Other Test Cases we could implement
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
    }







}
