using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    using Model;

    using Geo;

    class Program
    {
        static void Main(string[] args)
        {
            // This application creates a number of envelopes for the surface of the globe
            // The number of envelopes depends upon your delta for lat and long

            // Map sheets
            var mapSheets = new List<MapSheet>();
            
            double latitude = -90;
            double longitude = -180;
            
            // The amount of change per map sheet
            double deltaLat = 0.08;
            double deltaLong = 0.08;

            // Calculate how many maps we will need to make
            // 360 is the -180 to +180 long
            var iterationsLong = 360 / deltaLong;
            
            // Fill our maps
            for (int iLong = 0; iLong < iterationsLong; iLong++)
            {
                // 180 is the -90 to +90 lat
                var iterationsLat = 180 / deltaLat;

                // Populate our envelopes for each latitude in our iteration
                for (int iLat = 0; iLat < iterationsLat; iLat++)
                {
                    var mapSheet = new MapSheet()
                    {
                        Name = $"{iLat}",
                        AMGZone = "56",
                        Envelope = new Envelope(latitude, longitude, (latitude + deltaLat), (longitude + deltaLong)),
                        Number = iLat,
                        Scale = "1:25,000"
                    };
                    mapSheets.Add(mapSheet);

                    // Increment our Lat
                    latitude += deltaLat;
                }

                // Increment our long
                longitude += deltaLong;

                // Reset our lat
                latitude = -90;
            }

            // Query by coordinate
            var dateStart = DateTime.UtcNow;
            var map = mapSheets.FirstOrDefault(a => a.Envelope.Contains(new Coordinate(0.5, 0.5)));
            var dateEnd = DateTime.UtcNow;

            var elapsed = dateEnd - dateStart;

            Console.WriteLine("{0} to find one envelope in {1} envelopes ({2})", elapsed, mapSheets.Count, map.Name);
            Console.ReadKey();
        }
    }
}
