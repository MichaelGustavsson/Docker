namespace vehicles_api_net.Models;
public class Vehicle
{
  public int Id { get; set; }
  public string RegistrationNumber { get; set; } = "";
  public string Manufacturer { get; set; } = "";
  public string Model { get; set; } = "";
  public int ModelYear { get; set; }
}