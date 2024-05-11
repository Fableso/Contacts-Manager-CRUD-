using Entities;

namespace Contracts.DTO;

public class CountryRequest
{
    public string? CountryName { get; set; }
    public Country ToCountry() => new Country { Name = CountryName };
}