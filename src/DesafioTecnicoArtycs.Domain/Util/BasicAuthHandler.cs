using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DesafioTecnicoArtycs.Domain.Util
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private string _key;

        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IConfiguration config) : base(options, logger, encoder, clock)
        {
            _key = config.GetSection("Authentication").GetSection("ClientId").Value;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("apikey"))
            {
                return AuthenticateResult.Fail("API key Não encontrada");
            }

            try
            {
                var authHeader = Request.Headers["apikey"].ToString();
                if (authHeader != null && authHeader == _key)
                {
                    var claims = new[]
                    {
                            new Claim(ClaimTypes.Name, authHeader)
                        };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }

                else
                {
                    return AuthenticateResult.Fail("Credenciais inválidas");
                }
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            }
        }
    }
}
