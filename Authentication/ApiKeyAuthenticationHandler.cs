using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;


namespace SendMailApi.Authentication
{
   
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationSchemeOptions>
    {
        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<ApiKeyAuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock) { }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue("ApiKey", out StringValues apiKeyHeader))
            {
                return AuthenticateResult.Fail("ApiKey header not found");
            }

            string apiKey = apiKeyHeader.First();

            // You should implement your own logic here to validate the apiKey
            if (apiKey == "your-secret-api-key")
            {
                var claims = new[] { new System.Security.Claims.Claim("ApiKey", apiKey) };
                var identity = new System.Security.Claims.ClaimsIdentity(claims, Scheme.Name);
                var principal = new System.Security.Claims.ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Invalid API Key");
        }
    }

}
