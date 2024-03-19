using Interfaces.Enums;

namespace Interfaces.Models;

public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public Status Status { get; set; }
    public Department Department { get; set; }
    public Izinler Permission { get; set; }
}