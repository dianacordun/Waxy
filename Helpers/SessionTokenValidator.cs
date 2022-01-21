using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Repositories;
using Waxy.Repositories.SessionTokenRepository;

namespace Waxy.Helpers
{
    public class SessionTokenValidator
    {
        //verfica daca token-ul exista in baza de date && este valid
        public static async Task ValidateSessionToken(TokenValidatedContext context)
        {
            var repository = context.HttpContext.RequestServices.GetRequiredService<ISessionTokenRepository>();

            if (context.Principal.HasClaim(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)))
            {

                var jti = context.Principal.Claims.FirstOrDefault(c => c.Type.Equals(JwtRegisteredClaimNames.Jti)).Value;

                var tokenInDb = await repository.GetByJTI(jti);
                if (tokenInDb != null && tokenInDb.ExpirationDate > DateTime.Now)
                {
                    return;
                }
            }

            context.Fail("");
        }
    }
}
