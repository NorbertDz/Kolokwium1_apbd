using Kolokwium.Model.DTOs;
using Microsoft.Data.SqlClient;

namespace Kolokwium.Service;

public class reservationIdService : IreservationIdService
{
    private readonly IConfiguration _configuration;

    public reservationIdService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<resevationIdDTO> getReservationById(int id)
    {
        string command = @"Select date,guest_id,employee_id,booking_id from booking where booking_id=@bookingId ";
        
        resevationIdDTO reservationIdDTO = new resevationIdDTO();
        int guestId = 0;
        int employeeId = 0;
        int bookingId = 0;
        
        using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            await conn.OpenAsync();
            cmd.Parameters.AddWithValue("@bookingId", id);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    reservationIdDTO.date = reader.GetDateTime(0);
                    guestId = reader.GetInt32(1);
                    employeeId = reader.GetInt32(2);
                    bookingId = reader.GetInt32(3);
                }
            }
        }


        command = @"select first_name,last_name,date_of_birth from Guest where guest_id=@guestId ";
            
        using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            await conn.OpenAsync();
            cmd.Parameters.AddWithValue("@guestId", guestId);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    reservationIdDTO.guest = new Guest()
                    {
                        firstName = reader.GetString(0),
                        lastName = reader.GetString(1),
                        dateOfBirth = reader.GetDateTime(2),
                    };
                }
            }
        }
        
        command = @"select first_name,last_name,employeeNumber from Employee where employee_id=@employeeId ";
     
        
        using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            await conn.OpenAsync();
            cmd.Parameters.AddWithValue("@employeeId", employeeId);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    reservationIdDTO.employee = new Employee()
                    {
                        firstName = reader.GetString(0),
                        lastName = reader.GetString(1),
                        emlpoyeeNumber = reader.GetString(2),
                    };
                }
            }
        }
        
        command = @"Select a.name,a.price,ba.amount from Attraction a left join Booking_Attraction where a.booking_id=@bookingId";

        List<Attractions> attractions = new List<Attractions>(); 
        
        using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("Default")))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            await conn.OpenAsync();
            cmd.Parameters.AddWithValue("@bookingId", bookingId);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    attractions.Add(new Attractions
                    {
                        name = reader.GetString(0),
                        price = reader.GetDouble(1),
                        amount = reader.GetInt32(2)
                    });
                }
            }
            reservationIdDTO.attractions = attractions;
        }
        return reservationIdDTO;
    }
}