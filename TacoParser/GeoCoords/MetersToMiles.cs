namespace TacoParser.GeoCoords
{
    public static class MetersToMiles
    {
        public static double ConvertMetersToMiles(double distanceInMeters)
        {
            double distanceInMiles = distanceInMeters / 1609.34; // 1 mile = 1609.34 meters
            return Math.Round(distanceInMiles, 2);
        }
    }
}
