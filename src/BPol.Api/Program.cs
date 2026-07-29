using Microsoft.Extensions.Options;
using Shared.Web;
using Shared.Web.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(option =>
{
    option.OutputFormatters.Add(new BPol.Api.Formatters.CsvOutputFormatter());
    
});

builder.Services.AddFDGAuthentication(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCorrelationId();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
