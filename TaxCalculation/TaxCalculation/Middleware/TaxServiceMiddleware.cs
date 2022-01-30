using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using TaxCalculation.Abstractions;
using TaxCalculation.Models.TaxJar;
using TaxCalculation.Services;


namespace TaxCalculation.Middleware
{
    public static class TaxServiceMiddleware
    {
        public static IServiceCollection AddTaxServiceMiddleware(this IServiceCollection services, TaxServiceConfig config)
        {
            services.AddSingleton<ITaxService, TaxJarCalculator>();
            services.AddTransient((sc) => new AuthHeaderHandler(config));

            services.AddRefitClient<ITaxJarApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(config.TaxJarBaseUrl))
                .AddHttpMessageHandler<AuthHeaderHandler>();

            services.AddAutoMapper(
                typeof(Mappings.TaxJarRateMapping));
            return services;
        }
    }
}
