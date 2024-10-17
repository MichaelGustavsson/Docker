using Microsoft.AspNetCore.Mvc;
using vehicles_api_net.Models;

namespace vehicles_api_net.Controllers;

[ApiController]
[Route("api/v1/vehicles")]
public class VehiclesController : ControllerBase
{
  public IList<Vehicle> Vehicles { get; set; }

  public VehiclesController()
  {
    Vehicles =
    [
        new Vehicle
        {
          RegistrationNumber = "ABC123",
          Manufacturer = "Volvo",
          Model = "XC60",
          ModelYear = 2019
        },
    ];
  }

  [HttpGet()]
  public ActionResult<IList<Vehicle>> ListVehicles()
  {
    return Vehicles.ToList();
  }

  [HttpPost()]
  public ActionResult<Vehicle> AddVehicle(Vehicle vehicle)
  {
    return vehicle;
  }
}