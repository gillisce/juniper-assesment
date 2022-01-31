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
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, _config.TaxJarKey);
            }
            //request.Headers.Authorization = new AuthenticationHeaderValue("Token", _config.TaxJarKey);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
