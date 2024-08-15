using FluentAssertions;

namespace Lloyds.QET.Assessment.ApiTest
{
	public class StarShipsTest : Request
	{
        [Test]
        public async Task TestStarShips()
        {
            var responseBody = await SendGetRequest("starships/9");

            string name = responseBody["name"].GetValue<string>();
            string crew = responseBody["crew"].GetValue<string>();

            name.Should().Be("Death Star");
            crew.Should().Be("342,953");
        }
    }
}

