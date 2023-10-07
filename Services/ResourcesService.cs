using CarSeer.Interfaces;
using CarSeer.Models;

namespace CarSeer.Services
{
    public class ResourcesService : IResourcesService
    {
        private readonly ILocalFileReaderService _localFileReaderService;
        private readonly ICSVFileReaderService _CSVFileReaderService;

        private const string _rootFolderPath = "Resources";
        private const char _CSVFileColSplitter = ',';

        public ResourcesService(
            ILocalFileReaderService localFileReaderService,
            ICSVFileReaderService CSVFileReaderService)
        {
            _localFileReaderService = localFileReaderService;
            _CSVFileReaderService = CSVFileReaderService;
        }

        public List<CarMakeInfo> GetMakeInfo()
        {
            string filePath = $"{_rootFolderPath}/CarMake.csv";
            using (var reader = _localFileReaderService.LoadFile(filePath))
            {
                List<string> CSVFileRows = _CSVFileReaderService.GetCSVFileRows(reader);
                List<CarMakeInfo> data = CSVFileRows.Select(row =>
                {
                    string[] lineValues = row.Split(_CSVFileColSplitter, 2);
                    return new CarMakeInfo()
                    {
                        Id = int.Parse(lineValues[0]),
                        Name = lineValues[1]
                    };
                }).ToList();
                return data;
            }
        }
    }
}
