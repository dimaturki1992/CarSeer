using CarSeer.Interfaces;
using System.Text;

namespace CarSeer.Services
{
    public class LocalFileReaderService : ILocalFileReaderService
    {
        public StreamReader LoadFile(string relativeFilePath)
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeFilePath);
                if (File.Exists(filePath))
                {
                    FileStream stream = new FileStream(filePath, FileMode.Open);
                    return new StreamReader(stream, Encoding.UTF8);
                }
                else
                {
                    throw new FileNotFoundException("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
