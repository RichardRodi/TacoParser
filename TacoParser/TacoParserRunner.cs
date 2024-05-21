using TacoParser.GeoCoords;
using TacoParser.TacoBellnfo;
using TacoParser.TacoLog;

namespace TacoParser
{
    public class TacoParserRunner
    {
        private readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Parsing Data");
            var cells = line.Split(',');
            if (cells.Length < 3)
            {

                logger.LogWarning("less than three items");
                return null;
            }
            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var name = (cells[2]);
            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;
            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;
            return tacoBell;
        }
    }
}
