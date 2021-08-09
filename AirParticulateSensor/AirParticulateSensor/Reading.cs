using System;

namespace AirParticulateSensor
{
    public class Reading
    {
        public DateTime Date { get; }
        public int Value { get; }
        public double Temperature { get; }
        public double Humidity { get; }

        public Reading(DateTime date, int value, double temperature, double humidity)
        {
            this.Date = date;
            this.Value = value;
            this.Temperature = temperature;
            this.Humidity = humidity;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} ug/m³ {2} °C {3} %", this.Date.ToString("dd/MM/yyyy"), this.Value, this.Temperature, this.Humidity);
        }
    }
}
