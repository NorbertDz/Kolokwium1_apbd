using Kolokwium.Model.DTOs;
using Microsoft.Data.SqlClient;

namespace Kolokwium.Service;

public class addReservationService : IaddReservationService
{
    private readonly IConfiguration _configuration;

    public addReservationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<int> addReservation(getAttractions_Booking getattractions_booking)
    {
        if (!DoesVisitExist(getattractions_booking.booking_id).Result)
            return -1;

        string command = @"Select 1  from booking where booking_id=@bookingId ";
        
        using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            cmd.Parameters.AddWithValue("@bookingId", getattractions_booking.booking_id);
            conn.Open();
            var visit = cmd.ExecuteScalar();
            if (visit is null)
                return -2;
        }

        command = @"Select 1 from booking where guest_id=@guestId";
        
        using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            cmd.Parameters.AddWithValue("@guestId", getattractions_booking.guest_id);

            conn.Open();
            var visit = cmd.ExecuteScalar();
            if (visit is null)
                return -2;
        }
        
        
        command = "Select attracion_id from Attraction where attraction_id=@attractionId";
        using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            conn.Open();
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                    if (!(getattractions_booking.getdAttractions.Select<getdAttractions, object>(x => x.name)
                            .Contains(reader.GetString(0))))
                        return 0;
            }
        }
        command = "Insert into Booking (booking_id, guest_id, employee_id, date) values (@booking_id, @guest_id, @employee_id,date))";
        using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            cmd.Parameters.AddWithValue("@booking_id", getattractions_booking.booking_id);
            cmd.Parameters.AddWithValue("@guest_id", getattractions_booking.guest_id);
            cmd.Parameters.AddWithValue("@employee_id", getattractions_booking.employeeNumber);
            cmd.Parameters.AddWithValue("@Date", DateTime.Now);

            conn.Open();
            var id = cmd.ExecuteScalar();
            if (id is not null)
                return -4;
        }

        return 1;
    }
    
    public async Task<bool> DoesVisitExist(int id)
    {
        string command = "SELECT 1 FROM Bbooking WHERE booking_id = @bookingId";
        
        using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            cmd.Parameters.AddWithValue("@bookingId", id);
            conn.Open();
            var visit = cmd.ExecuteScalar();
            if (visit is not null)
                return false;
            return true;
        }

    }
}