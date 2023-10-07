
using CarSeer.Interfaces;

namespace CarSeer.Services
{
    public class CSVFileReaderService: ICSVFileReaderService
    {
        public List<string> GetCSVFileRows(StreamReader reader)
        {
            List<string> rows = new List<string>();
            while (!reader.EndOfStream)
            {
                string row = reader.ReadLine();
                rows.Add(row);
            }
            return rows;
        }
    }
}
