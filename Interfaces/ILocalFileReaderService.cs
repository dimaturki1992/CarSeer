namespace CarSeer.Interfaces
{
    public interface ILocalFileReaderService
    {
        StreamReader LoadFile(string relativeFilePath);
    }
}
