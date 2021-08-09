namespace AirParticulateSensor
{
    public interface ILocationFileReader
    {
        Location ReadLocationDataFromFile(ConfigRecord configRecord);
    }
}
