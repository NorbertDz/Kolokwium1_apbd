namespace Kolokwium.Service;

public class XService : IXService
{
    private readonly IConfiguration _configuration;

    public XService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    /*
     * public async Task nazwa(...)
     * public async Task<TypGeneryczny> nazwa(...)
     * {
     *      string zapytanie = @"";
     * 	    await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
	        await using SqlCommand command = new SqlCommand();
	        
			command.Connection = connection;
			command.CommandText = zapytanie;
			command.Parameters.AddWithValue("@ID", id);
			
     *      await connection.OpenAsync();
     *      var v1 = reader.GetOrdinal("parametr np Id");  
     *
     *     TypGeneryczny typgeneryczny(? opcjonalnie) = null;
     *          
			//gdy mamy sytuacje ze trzeba ta liste dac [] <- z tym
     *		while(await reader.ReadAsync())
     *		{
				if (typgeneryczny is not null)
		    	{
				    typgeneryczny.Procedures.Add(new ProcedureDto()
				    {
					    Date = reader.GetDateTime(dateOrdinal),
					    Name = reader.GetString(procedureNameOrdinal),
					    Description = reader.GetString(procedureDescriptionOrdinal)
				    });
		    	}
		    	else
		    	{
		    		//tworzymy np:
		    		animalDto = new AnimalDto()
			    {
				    Id = reader.GetInt32(animalIdOrdinal),
				    Name = reader.GetString(animalNameOrdinal),
				    Type = reader.GetString(animalTypeOrdinal),
				    AdmissionDate = reader.GetDateTime(admissionDateOrdinal),
				    Owner = new OwnerDto()
				    {
					    Id = reader.GetInt32(ownerIdOrdinal),
					    FirstName = reader.GetString(firstNameOrdinal),
					    LastName = reader.GetString(lastNameOrdinal),
				    },
				    Procedures = new List<ProcedureDto>()
				    {
					    new ProcedureDto()
					    {
						    Date = reader.GetDateTime(dateOrdinal),
						    Name = reader.GetString(procedureNameOrdinal),
						    Description = reader.GetString(procedureDescriptionOrdinal)
					    }
				    }
			    };
		    	
		    	}
     * 
     *		}
     *
     *        
     *
     *
     * 	    if (typgeneryczny is null) throw new Exception();
        
			return animalDto;
     *      }
     * }
     */
}