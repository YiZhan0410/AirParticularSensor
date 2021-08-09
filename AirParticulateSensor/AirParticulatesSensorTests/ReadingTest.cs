using System;

namespace AirParticulatesSensorTests
{
    public class ReadingTest
    {
        public String Date { get; }
        public int Value { get; }
        public double Temperature { get; }
        public double Humidity { get; }

        public ReadingTest(String date, int value, double temperature, double humidity)
        {
            this.Date = date;
            this.Value = value;
            this.Temperature = temperature;
            this.Humidity = humidity;
        }

        ReadingTest reading1 = new ReadingTest("18/02/2020",13,8.0,51.5);
        ReadingTest reading2 = new ReadingTest("19/02/2020",15,10.5,59.5);
    }
}
