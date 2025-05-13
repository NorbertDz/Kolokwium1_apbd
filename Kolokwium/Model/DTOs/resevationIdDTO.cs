namespace Kolokwium.Model.DTOs;

public class resevationIdDTO
{
    public DateTime date { get; set; }
    public Guest guest { get; set; }
    public Employee employee { get; set; }
    public List<Attractions> attractions { get; set; }
}

public class Guest
{
    public string firstName  { get; set; }
    public string lastName  { get; set; }
    public DateTime dateOfBirth { get; set; }
}

public class Employee
{
    public string firstName  { get; set; }
    public string lastName  { get; set; }
    public string emlpoyeeNumber { get; set; }
}

public class Attractions
{
    public string name { get; set; }
    public double price { get; set; }
    public int amount { get; set; }
}

