using Microsoft.AspNetCore.Authentication;

namespace SendMailApi
{
    public class ApiKeyAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
        public string ApiKey { get; set; }
    }
}
