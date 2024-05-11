using Contracts.DTO;

namespace Contracts;

public interface ICountriesService
{
    CountryResponse AddCountry(CountryRequest? countryRequest);
}