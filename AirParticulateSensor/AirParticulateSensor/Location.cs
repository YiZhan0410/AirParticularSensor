using System;
using System.Collections.Generic;

namespace AirParticulateSensor
{
    public class Location
    {
        public String LocationName { get; }
        public List<Reading> Readings { get; }

        public Location(String locationName)
        {
            this.LocationName = locationName;
            this.Readings = new List<Reading>();
        }

        public override String ToString()
        {
            return String.Format("Location: {0}", this.LocationName);
        }
    }
}
