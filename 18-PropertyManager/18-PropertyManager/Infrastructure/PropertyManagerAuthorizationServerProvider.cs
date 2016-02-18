using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace _18_PropertyManager.Infrastructure
{
    public class PropertyManagerAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // yak shaving
            // allow cors here as well
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            // validate the user
            // 'using' statement allows for the object to be 'alive' within the using statement
            using (var authRepository = new AuthorizationRepository())
            {
                var user = await authRepository.FindUser(context.UserName, context.Password);
                // username/password do not match OR user does not exist
                if (user == null)
                {
                    context.SetError("invalid_grant", "The username or password is incorrect");
                    return;
                }
                // if user was found
                else
                {
                    var token = new ClaimsIdentity(context.Options.AuthenticationType);
                    token.AddClaim(new Claim("sub", context.UserName));
                    token.AddClaim(new Claim("role", "user"));

                    context.Validated(token);
                }
            }
        }
    }
}