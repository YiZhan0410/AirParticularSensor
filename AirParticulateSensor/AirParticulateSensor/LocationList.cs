using System;
using System.Collections.Generic;
using System.Linq;

namespace AirParticulateSensor
{
    public class LocationList
    {
        public List<Location> Locations { get; }

        public LocationList()
        {
            this.Locations = new List<Location>();
        }

        public List<String> DisplayLocationAscending()
        {
            var locationList = new List<string>();

            var locationAscending =
                from location in this.Locations
                orderby location.LocationName
                select location;

            var read =
                from loc in this.Locations
                from reading in loc.Readings
                orderby reading.Date
                select reading;
         
            foreach (var l in locationAscending)
            {
                locationList.Add(String.Format("{0}", l));
            }

            return locationList;
        }

        public List<String> DisplayDates()
        {
            var locationList = new List<string>();

            var dates =
                    from location in this.Locations
                    from reading in location.Readings
                    orderby reading.Date
                    select new
                    {
                        Name = location.LocationName,
                        date = reading.Date,
                        value = reading.Value,
                        temperature = reading.Temperature,
                        humidity = reading.Humidity
                    };

            foreach (var d in dates)
            {
                locationList.Add(String.Format("{0}: {1} - {2} ug/m³ {3} °C {4} %", d.Name, d.date.ToString("dd/MM/yyyy"),d.value,d.temperature,d.humidity));
            }

            return locationList;
        }

        public List<String> DisplayLargest()
        {
            var locationList = new List<string>();

            var largest =
                from location in this.Locations
                from reading in location.Readings
                let large = location.Readings.Max(x => x.Value)
                where reading.Value > 26
                select new
                {
                    loc = location.LocationName,
                    date = reading.Date,
                    value = reading.Value
                };

                foreach (var m in largest)
                {
                    locationList.Add(String.Format("{0}: {1} - {2} ug/m³",m.loc, m.date.ToString("dd/MM/yyyy"), m.value));
                }


            return locationList;
        }

        public List<String> DisplayLocationReading()
        {
            var locationList = new List<string>();

            var all =
                from location in this.Locations
                from reading in location.Readings
                group reading by reading.Date into dates
                orderby dates ascending
                select dates;

            return locationList;
        }

        public List<String> DisplayDatesOnly()
        {
            var locationList = new List<string>();

            var dates =
                from location in this.Locations
                from reading in location.Readings
                orderby location.LocationName
                select new
                {
                    date = reading.Date,
                    value = reading.Value,
                    temperature = reading.Temperature,
                    humidity = reading.Humidity
                };

            foreach (var d in dates)
            {
                locationList.Add(String.Format("{0} - {1} ug/m³ {2} °C {3} %", d.date.ToString("dd/MM/yyyy"), d.value, d.temperature, d.humidity));
            }

            return locationList;
        }


    }

}
