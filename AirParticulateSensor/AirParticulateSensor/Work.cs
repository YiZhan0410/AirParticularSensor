namespace AirParticulateSensor
{
    public class Work
    {
        public ConfigRecord configRecord { get; } // Data used when this work is processed - config record
        private ILocationFileReader IOhandler; // Data used when this work is procesed - config record

        public Work(ConfigRecord data, ILocationFileReader IOhandler)
        {
            this.configRecord = data;// Data is initialised when the work is instantiated
            this.IOhandler = IOhandler;
        }

        public Location ReadData()
        {
            // Reads the specified file and extracts the constituency data from it to store in a Location object
            return IOhandler.ReadLocationDataFromFile(configRecord);
        }
    }
}
