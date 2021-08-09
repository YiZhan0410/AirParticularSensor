namespace AirParticulateSensor
{
    public interface IUserInterface
    {
        void SetupConfigData();
        void RunProducerConsumer();
        void DisplayLocations();
        void DisplayDates();
        void DisplayLargestParticulates();
        void DisplayLocationReadings();
        void DisplayDatesOnly();
    }
}
