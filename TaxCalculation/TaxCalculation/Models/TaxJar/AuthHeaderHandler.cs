using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace TaxCalculation.Models.TaxJar
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        public readonly TaxServiceConfig _config;

        public AuthHeaderHandler(TaxServiceConfig config)
        {
            _config = config;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Make sure request has an authorize header
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _config.TaxJarKey);
            }
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
