using CarSeer.Interfaces;
using CarSeer.Models;

namespace CarSeer.Services
{
    public class CarMakeInfoService : ICarMakeInfoService
    {
        private readonly ILocalFileReaderService _localFileReaderService;
        private readonly ICSVFileReaderService _CSVFileReaderService;

        private List<CarMakeInfo> _makeIdNamePairs;

        private const string FilePath = "Resources/CarMake.csv";
        private const char CSVFileColSplitter = ',';
       
        public CarMakeInfoService(
            ILocalFileReaderService localFileReaderService,
            ICSVFileReaderService CSVFileReaderService
            )
        {
            _localFileReaderService = localFileReaderService;
            _CSVFileReaderService = CSVFileReaderService;
        }

        public int GetMakeId(string make)
        {
            var data = GetIdNamePairs();
            var matchingRow = data.FirstOrDefault(row => row.Name.ToLower() == make.ToLower());
            return matchingRow.Id;
        }

        private List<CarMakeInfo> GetIdNamePairs()
        {
            if (_makeIdNamePairs == null)
            {
                _makeIdNamePairs = ReadMakeInfo();
            }
            return _makeIdNamePairs;

        }

        private List<CarMakeInfo> ReadMakeInfo()
        {
            using var reader = _localFileReaderService.LoadFile(FilePath);
            List<string> CSVFileRows = _CSVFileReaderService.GetCSVFileRows(reader);
            List<CarMakeInfo> data = CSVFileRows.Select(row =>
            {
                string[] lineValues = row.Split(CSVFileColSplitter);
                return new CarMakeInfo()
                {
                    Id = int.Parse(lineValues[0]),
                    Name = lineValues[1].Trim('"')
                };
            }).ToList();
            return data;
        }

    }
}
