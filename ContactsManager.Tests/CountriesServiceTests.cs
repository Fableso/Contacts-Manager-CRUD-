using Contracts;
using Services;

namespace ContactsManager.Tests;

public class CountriesServiceTests
{
    private readonly ICountriesService _countriesService;

    public CountriesServiceTests()
    {
        _countriesService = new CountriesService();
    }
    [Fact]
    public void Test1()
    {
    }
}