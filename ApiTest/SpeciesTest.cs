using FluentAssertions;

namespace Lloyds.QET.Assessment.ApiTest
{
	public class SpeciesTest : Request
	{
		[Test]
        public async Task TestSpecies()
        {
            var responseBody = await SendGetRequest("species/3");

            string name = responseBody["name"].GetValue<string>();
            string classification = responseBody["classification"].GetValue<string>();

            name.Should().Be("Wookie");
            classification.Should().Be("mammal");
        }
    }
}

