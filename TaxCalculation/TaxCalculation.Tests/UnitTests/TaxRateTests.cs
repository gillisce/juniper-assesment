using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Abstractions;
using TaxCalculation.Mappings;
using TaxCalculation.Models;
using TaxCalculation.Models.TaxJar;
using TaxCalculation.Services;

namespace TaxCalculation.Tests.UnitTests
{
    [TestClass]
    public class TaxRateTests
    {
        private readonly ITaxService _taxService;
        public TaxRateTests()
        {
            var taxConfig = new TaxServiceConfig();
            var taxJarApi = RestService.For<ITaxJarApi>(new HttpClient(new AuthHeaderHandler(taxConfig))
            {
                BaseAddress = new Uri(taxConfig.TaxJarBaseUrl)
            });
           var mapper = new Mapper(new MapperConfiguration(cfg => {
               cfg.AddProfile<TaxJarRateMapping>();
               cfg.AddProfile<TaxJarRateResponseMapping>();
           }));
            _taxService = new TaxJarCalculator(taxJarApi, mapper );

        }

        [TestMethod]
        public void GetTaxRateForUSLocation()
        {
            var taxRequest = new BasicTaxRateRequest()
            {
                Zip = "90404",
                Country = "US",
                City = "Santa Monica"
            };

            var expectedResult = new TaxRateObject
            {
                CountryRate = 0,
                CombinedRate = 0.1025,
                CombinedDistrictRate = 0.03,
                StateRate = 0.0625,
                CityRate = 0,
            };

            var taxJarResponse =  _taxService.GetTaxRateByLocation(taxRequest).Result;
            foreach(var pi in expectedResult.GetType().GetProperties())
			{
                Assert.AreEqual(pi.GetValue(expectedResult), pi.GetValue(taxJarResponse));
			}

        }

        [TestMethod]
        public void GetTaxRateForUSLocationWithStreet()
        {
            var taxRequest = new BasicTaxRateRequest()
            {
                Zip = "98109",
                Country = "US",
                City = "Seattle",
                Street = "400 Broad St"
            };

            var expectedResult = new TaxRateObject
            {
                CountryRate = 0,
                CombinedRate = 0.1025,
                CombinedDistrictRate = 0.023,
                StateRate = 0.065,
                CityRate = 0.0115,
            };

            var taxJarResponse = _taxService.GetTaxRateByLocation(taxRequest).Result;
            foreach (var pi in expectedResult.GetType().GetProperties())
            {
                Assert.AreEqual(pi.GetValue(expectedResult), pi.GetValue(taxJarResponse));
            }

        }


        [TestMethod]
		public void GetTaxRateForCanadaianLocation()
		{
			var taxRequest = new BasicTaxRateRequest()
			{
				Zip = "V5K0A1",
				Country = "CA",
				City = "Vancouver"
			};
            var expectedResult = new TaxRateObject
            {
                CountryRate = 0,
                CombinedRate = 0.12,
                CombinedDistrictRate = 0,
                StateRate = 0,
                CityRate = 0,
            };

            var taxJarResponse = _taxService.GetTaxRateByLocation(taxRequest).Result;
            foreach (var pi in expectedResult.GetType().GetProperties())
            {
                Assert.AreEqual(pi.GetValue(expectedResult), pi.GetValue(taxJarResponse));
            }
        }


		[TestMethod]
		public void GetTaxRateForInternational()
		{
			var taxRequest = new BasicTaxRateRequest()
			{
				Zip = "00150",
				Country = "FI",
				City = "Helsinki"
			};

            var expectedResult = new TaxRateObject
            {
                DistanceSaleThreshold = 0,
                ParkingRate = 0,
                ReducedRate = 0.14,
                StandardRate = 0.24,
                SuperReducedRate = 0.1,
            };

            var taxJarResponse = _taxService.GetTaxRateByLocation(taxRequest).Result;
            foreach (var pi in expectedResult.GetType().GetProperties())
            {
                Assert.AreEqual(pi.GetValue(expectedResult), pi.GetValue(taxJarResponse));
            }

        }


		[TestMethod]
		public void GetTaxRateWithoutCountryAndCity()
		{
			var taxRequest = new BasicTaxRateRequest()
			{
				Zip = "90404",
			};

            var expectedResult = new TaxRateObject
            {
                CountryRate = 0,
                CombinedRate = 0.1025,
                CombinedDistrictRate = 0.03,
                StateRate = 0.0625,
                CityRate = 0,
            };

            var taxJarResponse = _taxService.GetTaxRateByLocation(taxRequest).Result;
            foreach (var pi in expectedResult.GetType().GetProperties())
            {
                Assert.AreEqual(pi.GetValue(expectedResult), pi.GetValue(taxJarResponse));
            }
        }

	}
}
