using Entities;

namespace Contracts.DTO.Extensions;

public static class DTOExtensions
{
    public static CountryResponse ToCountryResponse(this Country country)
    {
        return new CountryResponse
        {
            CountryId = country.CountryID,
            CountryName = country.Name,
        };
    }
}