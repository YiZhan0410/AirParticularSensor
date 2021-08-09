using System.Collections.Generic;

namespace AirParticulateSensor
{
    public class ConfigData
    {
        public List<ConfigRecord> configRecords { get; }

        public int NextRecord { get; set; }

        public ConfigData()
        {
            this.NextRecord = 0;
            configRecords = new List<ConfigRecord>();
        }
    }
}
