using GeoCoordinatePortable;
using TacoParser.GeoCoords;
using TacoParser.TacoLog;

namespace TacoParser
{
    class Program
    {

        static readonly ILog logger = new TacoLogger();
        const string csvPath = "C:\\Users\\Rich Rodi\\Desktop\\ReDoneProjects\\TacoParser\\TacoParser\\TacoBellnfo\\TacoBell-US-AL.csv";
        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            var lines = File.ReadAllLines(csvPath);

            if (lines.Length == 0)
            {
                logger.LogError("This Item has 0 Lines");
            }
            if (lines.Length == 1)
            {
                logger.LogWarning("This item has 1 Line");
            }
            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParserRunner();
            var locations = lines.Select(parser.Parse).ToArray();
            ITrackable nearest = null;
            ITrackable furthest = null;
            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate();
                corA.Longitude = locA.Location.Longitude;
                corA.Latitude = locA.Location.Latitude;
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate();
                    corB.Longitude = locB.Location.Longitude;
                    corB.Latitude = locB.Location.Latitude;

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        nearest = locA;
                        furthest = locB;
                    }
                }
            }

            var distanceInMiles = MetersToMiles.ConvertMetersToMiles(distance);
            Console.WriteLine($"\n\nThe Two Furthest Stores from each other are {nearest.Name}, and {furthest.Name},\nThe Distance Between them is {distanceInMiles} miles");
            Console.ReadKey();


        }
    }
   
}
