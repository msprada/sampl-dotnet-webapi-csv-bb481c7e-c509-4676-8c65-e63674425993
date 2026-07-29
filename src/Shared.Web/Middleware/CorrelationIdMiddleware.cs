namespace Shared.Web.Middleware
{
    using System.Net.Cache;
    using Microsoft.AspNetCore.Http;

    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private const string CorrelationIdHeader = "X-Correlation-ID";

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            this._next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            var correlationId = GetOrCreateCorrelationId(context);

            context.Items[CorrelationIdHeader] = correlationId;


            context.Response.OnStarting(() =>
            {
                context.Response.Headers[CorrelationIdHeader] = correlationId;
                return Task.CompletedTask;
            });

            await _next(context);
        }

        private string GetOrCreateCorrelationId(HttpContext context)
        {

            string returnValue = String.Empty;

            returnValue = this.GetExistingCorrelatonIdFromHeader(context);

            if (String.IsNullOrEmpty(returnValue))
            {
                returnValue = this.CreateNewCorrelationId();
            }

            return returnValue;
        }

        private string GetExistingCorrelatonIdFromHeader(HttpContext context)
        {
            string returnValue = String.Empty;

            if (context.Request.Headers.TryGetValue(CorrelationIdHeader, out var existingId) && !String.IsNullOrEmpty(existingId))
            {
                returnValue = existingId.ToString();
            }

            return returnValue;

        }

        private string CreateNewCorrelationId()
        {
            return Guid.NewGuid().ToString();
        }

    }

}