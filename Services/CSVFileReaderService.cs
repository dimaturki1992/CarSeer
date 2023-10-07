using CarSeer.Interfaces;

namespace CarSeer.Services
{
    public class CSVFileReaderService : ICSVFileReaderService
    {
        public List<string> GetCSVFileRows(StreamReader reader)
        {
            try
            {
                List<string> rows = new List<string>();
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    rows.Add(row);
                }
                return rows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
