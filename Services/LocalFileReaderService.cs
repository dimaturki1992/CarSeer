using CarSeer.Interfaces;
using System.Text;

namespace CarSeer.Services
{
    public class LocalFileReaderService: ILocalFileReaderService
    {
        public StreamReader LoadFile(string relativeFilePath)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);
            FileStream stream = new FileStream(filePath, FileMode.Open);
            return new StreamReader(stream, Encoding.UTF8);
        }
    }
}
