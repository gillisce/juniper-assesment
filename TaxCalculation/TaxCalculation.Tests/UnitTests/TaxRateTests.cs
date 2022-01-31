using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculation.Models;

namespace TaxCalculation.Tests.UnitTests
{
    [TestClass]
    public class TaxRateTests
    {

        [TestMethod]
        public void GetTaxRateForUSLocation()
        {
            var taxRequest = new BasicTaxRateRequest()
            {
                Zip = "90404",
                Country = "US",
                City = "Santa Monica"
            };


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

        }


        [TestMethod]
        public void GetTaxRateWithoutCountryAndCity()
        {
            var taxRequest = new BasicTaxRateRequest()
            {
                Zip = "90404",
            };
            //Expected Failure
        }

    }
}
