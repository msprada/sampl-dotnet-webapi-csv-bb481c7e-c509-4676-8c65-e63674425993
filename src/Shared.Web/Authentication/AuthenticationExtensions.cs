namespace Shared.Web.Authentication
{

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.Identity.Web;

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
