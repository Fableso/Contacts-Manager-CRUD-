using Contracts.DTO;

namespace Contracts.Interfaces;

public interface ICountriesService
{
    CountryResponse AddCountry(CountryRequest? countryRequest);

    IList<CountryResponse> GetAllCountries();

    CountryResponse? GetCountryById(Guid? countryId);
}