using Kolokwium.Model.DTOs;

namespace Kolokwium.Service;

public interface IaddReservationService
{
    Task<int> addReservation(getAttractions_Booking getattractions_booking);
}