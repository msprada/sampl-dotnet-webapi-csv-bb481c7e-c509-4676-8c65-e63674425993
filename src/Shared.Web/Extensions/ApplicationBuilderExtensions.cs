

namespace Shared.Web
{

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions;
    using Shared.Web.Middleware;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCorrelationId(
            this IApplicationBuilder app)
        {
            return app.UseMiddleware<CorrelationIdMiddleware>();
        }
    }
}

