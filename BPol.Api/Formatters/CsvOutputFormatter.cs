using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using BPol.Api.Models;

namespace BPol.Api.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add("text/csv");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(FlightDataItem).IsAssignableFrom(type) || typeof(IEnumerable<FlightDataItem>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(
        OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var httpContext = context.HttpContext;
            var serviceProvider = httpContext.RequestServices;

            var logger = serviceProvider.GetRequiredService<ILogger<CsvOutputFormatter>>();
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<FlightDataItem> flights)
            {
                foreach (var flight in flights)
                {
                    FormatCsv(buffer, flight, logger);
                }
            }
            else
            {
                FormatCsv(buffer, (FlightDataItem)context.Object!, logger);
            }

            await httpContext.Response.WriteAsync(buffer.ToString(), selectedEncoding);
        }

        private static void FormatCsv(
        StringBuilder buffer, FlightDataItem flight, ILogger logger)
        {
            buffer.AppendLine($"{flight.FlightNumber},{flight.DepartureAirport},{flight.ArrivalAirport},{flight.DepartureTime},{flight.ArrivalTime}");
            logger.LogInformation("Writing flight {FlightNumber}", flight.FlightNumber);
        }

    }





}