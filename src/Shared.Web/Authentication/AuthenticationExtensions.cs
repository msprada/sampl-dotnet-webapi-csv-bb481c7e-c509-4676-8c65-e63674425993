namespace Shared.Web.Authentication
{

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Identity.Web;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;

    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddFDGAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services
                .AddOptions<OAuthProviderOptions>()
                .Bind(configuration.GetSection(OAuthProviderOptions.SectionName))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(configuration.GetSection(OAuthProviderOptions.SectionName));

            services.AddAuthorization();

            return services;


        }
    }
}