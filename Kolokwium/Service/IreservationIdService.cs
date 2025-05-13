using Kolokwium.Model.DTOs;

namespace Kolokwium.Service;

public interface IreservationIdService
{
    Task<resevationIdDTO> getReservationById(int id);
}