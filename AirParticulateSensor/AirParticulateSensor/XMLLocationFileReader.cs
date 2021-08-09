using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace AirParticulateSensor
{
    public class XMLLocationFileReader : ILocationFileReader
    {
        public Location ReadLocationDataFromFile(ConfigRecord configRecord)
        {
            // Open the file to read from on the local file system
            // return from this method if this file is missing
            if (!File.Exists(configRecord.Filename))
            {
                // return null if file cannot open
                return null;
            }

            // Open and load XML file
            XDocument xmlDoc = XDocument.Load(configRecord.Filename);

            // Create location
            var loc = (from l in xmlDoc.Descendants("Location")
                       select l).First();

            Location location = new Location(loc.Attribute("name").Value);

            // Get readings from this location
            var read = from r in loc.Descendants("Reading")
                          select r;

            foreach (var r in read)
            {
                var date = DateTime.Parse(r.Attribute("date").Value);
                var value = Int32.Parse(r.Element("value").Value);
                var temperature = Double.Parse(r.Element("temperature").Value);
                var humidity = Double.Parse(r.Element("humidity").Value);

                Reading reading = new Reading(date, value, temperature, humidity);
                location.Readings.Add(reading);
            }

            return location;
        }
    }
}
