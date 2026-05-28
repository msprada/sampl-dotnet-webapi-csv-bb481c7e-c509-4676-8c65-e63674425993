using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BPol.Api.Models;

namespace BPol.Api.Controllers;

[Route("api/[controller]")]
public class FlightsController : Controller
{

    [HttpGet]
    public IEnumerable<FlightDataItem> Index()
    {
        var flights = new List<FlightDataItem>
        {
            new FlightDataItem
            {
                FlightNumber = "AA123",
                DepartureAirport = "JFK",
                ArrivalAirport = "LAX",
                DepartureTime = DateTime.UtcNow.AddHours(2),
                ArrivalTime = DateTime.UtcNow.AddHours(5)
            },
            new FlightDataItem
            {
                FlightNumber = "DL456",
                DepartureAirport = "ATL",
                ArrivalAirport = "ORD",
                DepartureTime = DateTime.UtcNow.AddHours(3),
                ArrivalTime = DateTime.UtcNow.AddHours(6)
            }
        };

        return flights;


    }
}
