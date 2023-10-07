namespace CarSeer.Interfaces
{
    public interface ICSVFileReaderService
    {
        List<string> GetCSVFileRows(StreamReader reader);
    }
}
