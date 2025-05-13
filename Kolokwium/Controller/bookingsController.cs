using Kolokwium.Model.DTOs;
using Kolokwium.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controller;

[Route("api/[controller]")]
[ApiController]
public class bookingsController : ControllerBase
{
    private readonly IreservationIdService _ireservationIdService;
    private readonly IaddReservationService _iaddReservationService;
    public bookingsController(IreservationIdService ireservationIdService, IaddReservationService iaddReservationService)
    {
        _ireservationIdService = ireservationIdService;
        _iaddReservationService = iaddReservationService;
    }
    
    [HttpGet("{id}")]
    public IActionResult getReservationById(int id)
    {
        
        var reservation = _ireservationIdService.getReservationById(id);
        if (reservation == null)
        {
            return NotFound();
        }
        return Ok(reservation.Result);
    }
    
    [HttpPost("")]
    public IActionResult CreateAppointment([FromBody] getAttractions_Booking? getattractions_booking)
    {
        if (getattractions_booking is null || getattractions_booking.booking_id == null)
            return BadRequest("Invalid appointment data.");


        var addReservation = _iaddReservationService.addReservation(getattractions_booking);
        if (addReservation.Result == -1)
            return BadRequest("Appointment already exists.");
        else if (addReservation.Result == -2)
            return NotFound("Patient or doctor not found.");
        else if (addReservation.Result == -3)
            return NotFound("Service not found.");
        else if (addReservation.Result == -4)
            return BadRequest("Cos");
            
        if (addReservation.Result == 1)
            return Created(nameof(getattractions_booking), "Created appointment");

        return BadRequest("No");
    }
}