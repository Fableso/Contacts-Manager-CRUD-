using Contracts;
using Contracts.DTO;
using Contracts.Interfaces;
using Services;

namespace ContactsManager.Tests;

public class CountriesServiceTests
{
    private readonly ICountriesService _countriesService;

    public CountriesServiceTests()
    {
        _countriesService = new CountriesService();
    }

    #region AddCountryTests
    [Fact]
    public void AddCountry_NullCountry_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _countriesService.AddCountry(null));
    }
    
    [Fact]
    public void AddCountry_NullCountryName_ThrowsArgumentException()
    {
        var request = new CountryRequest { CountryName = null };
        Assert.Throws<ArgumentException>(() => _countriesService.AddCountry(request));
    }
    
    [Fact]
    public void AddCountry_DuplicateCountry_ThrowsArgumentException()
    {
        var request = new CountryRequest { CountryName = "Ukraine" };
        Assert.Throws<ArgumentException>(() =>
        {
            _countriesService.AddCountry(request);
            _countriesService.AddCountry(request);
        });
    }
    
    [Fact]
    public void AddCountry_ValidCountry_AddsANewCountry()
    {
        //TODO: Add db adding verification after implementing DbContext
        var request = new CountryRequest { CountryName = "Poland" };

        var response = _countriesService.AddCountry(request);
        
        Assert.True(response.CountryId != Guid.Empty);
    }
    #endregion

    #region GetAllCountriesTests

    [Fact]
    public void GetAllCountries_NoCountriesPresent_ReturnsEmptyList()
    {
        var fetchedCountries = _countriesService.GetAllCountries();
        Assert.Empty(fetchedCountries);
    }

    [Fact]
    public void GetAllCountries_AddCountries_ReturnsAddedCountries()
    {
        var countriesToAdd = new List<CountryRequest>
        {
            new CountryRequest { CountryName = "Ukraine" },
            new CountryRequest { CountryName = "Poland" },
            new CountryRequest { CountryName = "USA" },
        };

        var addedCountries = countriesToAdd.Select(country => _countriesService.AddCountry(country)).ToList();

        var fetchedCountries = _countriesService.GetAllCountries();

        foreach (var expectedCountry in addedCountries)
        {
            Assert.Contains(expectedCountry, fetchedCountries);
        }
    }
    
    #endregion

    #region GetCountryByIdTests

    [Fact]
    public void GetCountryById_NullCountryId_ReturnsNull()
    {
        var fetchedCountry = _countriesService.GetCountryById(null);
        Assert.Null(fetchedCountry);
    }

    [Fact]
    public void GetCountryById_ValidCountryId_ReturnsCountry()
    {
        var countryToAdd = new CountryRequest { CountryName = "Ukraine" };
        var addedCountry = _countriesService.AddCountry(countryToAdd);

        var fetchedCountry = _countriesService.GetCountryById(addedCountry.CountryId);
        Assert.Equal(addedCountry, fetchedCountry);
    }
    #endregion
}