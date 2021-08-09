using System;

namespace AirParticulateSensor
{
    public class ConfigRecord
    {
        public String Filename { get; }

        public ConfigRecord(String Filename)
        {
            this.Filename = Filename;
        }

        public override string ToString()
        {
            return String.Format("{0}", Filename);
        }
    }
}
