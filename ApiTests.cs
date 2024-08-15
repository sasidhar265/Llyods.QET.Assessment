using System.Text.Json.Nodes;
using FluentAssertions;

namespace Lloyds.QET.Assessment;

public class ApiTests
{
    // constant string object same for every endpoint
    private const string _baseUrl = "https://swapi.dev/api/";

    // common method to send GET request by taking endpoint as parameter
    private async Task<JsonNode?> GetAsync(string endpoint)
    {
        HttpClient httpClient = new HttpClient();
        var response = await httpClient.GetAsync(_baseUrl + endpoint);
        var responseContent = await response.Content.ReadAsStringAsync();
        var responseBody = JsonNode.Parse(responseContent);
        return responseBody;
    }

    [Ignore ("Ignore People Test")]
    public async Task TestPeople()
    {
        // sending request to get details based on endpoint and its value
        var responseBody = await GetAsync("people/3");

        // getting respective value based on key from json response body
        string name = responseBody["name"].GetValue<string>();
        string skinColor = responseBody["skin_color"].GetValue<string>().Replace(",", "and");

        // asserting response key value using fluent assertions with expected value
        name.Should().Be("R2-D2");
        skinColor.Should().Be("White and Blue");
    }

    [Ignore("Ignore Startship Test")]
    public async Task TestStarShips()
    {
        var responseBody = await GetAsync("starships/9");

        string name = responseBody["name"].GetValue<string>();
        string crew = responseBody["crew"].GetValue<string>();

        name.Should().Be("Death Star");
        crew.Should().Be("342,953");
    }

    [Ignore("Ignore Species Test")]
    public async Task TestSpecies()
    {
        var responseBody = await GetAsync("species/3");

        string name = responseBody["name"].GetValue<string>();
        string classification = responseBody["classification"].GetValue<string>();

        name.Should().Be("Wookie");
        classification.Should().Be("mammal");
    }
}
