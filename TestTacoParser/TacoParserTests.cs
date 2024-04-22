using TacoParser;
namespace TestTacoParser
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            var tacoParser = new TacoParserRunner();
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("31.236691, -85.459825, Taco Bell Dothan...", -85.459825)]
        [InlineData("33.891307, -84.754816, Taco Bell Hira...", -84.754816)]
        [InlineData("33.585846, -84.338763, Taco Bell Morrow...", -84.338763)]
        [InlineData("34.272015, -85.229599, Taco Bell Rome...", -85.229599)]
        [InlineData("31.935914, -87.737701, Taco Bell Thomasville...", -87.737701)]

        public void ShouldParseLongitude(string line, double expected)
        {
            var tacoParser = new TacoParserRunner();
            var actual = tacoParser.Parse(line);
            Assert.Equal(expected, actual.Location.Longitude);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("31.236691, -85.459825, Taco Bell Dothan...", 31.236691)]
        [InlineData("33.891307, -84.754816, Taco Bell Hira...", 33.891307)]
        [InlineData("33.585846, -84.338763, Taco Bell Morrow...", 33.585846)]
        [InlineData("34.272015, -85.229599, Taco Bell Rome...", 34.272015)]
        [InlineData("31.935914, -87.737701, Taco Bell Thomasville...", 31.935914)]
        public void ShouldParseLatitude(string line, double expected)
        {

            var tacoParser = new TacoParserRunner();
            var actual = tacoParser.Parse(line);
            Assert.Equal(expected, actual.Location.Latitude);
        }
    }
}