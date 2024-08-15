using System.Text.Json.Nodes;

namespace Lloyds.QET.Assessment.ApiTest
{
	public class Request
	{
        // constant string object same for every endpoint
        private const string _baseUrl = "https://swapi.dev/api/";

        // common method to send GET request by taking endpoint as parameter
        protected async Task<JsonNode?> SendGetRequest(string endpoint)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_baseUrl + endpoint);
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseBody = JsonNode.Parse(responseContent);
            return responseBody;
        }
    }
}

