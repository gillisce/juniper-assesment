﻿using AutoMapper;
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
            var taxJarRequestObject = _mapper.Map<TaxRate>(_input);

            //Instead of writing out the whole 
            //using (var client = newHttpClient())
            //{
            //    client.BaseAddress = newUri("TaxJarURLHERE");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(newMediaTypeWithQualityHeaderValue("application/json"));
            //    //GET Method
            //    HttpResponseMessage response = awaitclient.GetAsync("APIRoute");
            //}
            //Since that can bog down the code, instead I will be using Refit, which allows me to spin up an interface that under the hood will do all that config work for an HTTPClient. This helps ensure we always dispose and allows for cleaner Dependency Injection
            
            //Refit way to call the API Endpoint of tax jar
            var response = _taxJar.GetTaxRate(taxJarRequestObject.Zip, taxJarRequestObject.Country, taxJarRequestObject.City);
            return new TaxRateObject();
        }



    }
}