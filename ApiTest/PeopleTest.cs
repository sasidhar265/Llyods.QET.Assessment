using FluentAssertions;

namespace Lloyds.QET.Assessment.ApiTest
{
	public class PeopleTest : Request
	{
        [Test]
        public async Task TestPeople()
        {
            // sending request to get details based on endpoint and its value
            var responseBody = await SendGetRequest("people/3");

            // getting respective value based on key from json response body
            string name = responseBody["name"].GetValue<string>();
            string skinColor = responseBody["skin_color"].GetValue<string>().Replace(",", " and");

            // asserting response key value using fluent assertions with expected value
            name.Should().Be("R2-D2");
            skinColor.Should().Be("white and blue");
        }
    }
}