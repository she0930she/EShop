using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthenticationManager;

public static class CustomJwtAuthExtension
{
    public static void AddCustomJwtAuthentication(this IServiceCollection service)
    {
        service.AddAuthentication(o => {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(o => { 
            o.RequireHttpsMetadata = false;
            o.SaveToken = true;
            o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters { 
                ValidateIssuerSigningKey = true,
                ValidateIssuer=false,
                ValidateAudience=false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtTokenHandler.JWT_SECURITY_KEY))
            };
        });
    }
}