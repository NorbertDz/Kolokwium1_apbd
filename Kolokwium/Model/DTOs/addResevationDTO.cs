namespace Kolokwium.Model.DTOs;

public class addResevationDTO
{
    public int bookingId { get; set; }
    public int guestId { get; set; }
    public string employeeNumber { get; set; }
    
}

public class getdAttractions
{
    public string name { get; set; }
    public int amount { get; set; }
}

public class getAttractions_Booking
{
    public int booking_id { get; set; }
    public int guest_id { get; set; }
    public string employeeNumber { get; set; }
    public List<getdAttractions> getdAttractions { get; set; }
}