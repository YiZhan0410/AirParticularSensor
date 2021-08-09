using System;
using System.Collections.Generic;

namespace AirParticulatesSensorTests
{
    public class LocationTest
    {
        public String LocationName { get; }
        public List<ReadingTest> Readings { get; }

        public LocationTest(String locationName)
        {
            this.LocationName = locationName;
            this.Readings = new List<ReadingTest>();
        }

        LocationTest location1 = new LocationTest("Quayside");
        LocationTest location2 = new LocationTest("St. Peters");
    }
}
