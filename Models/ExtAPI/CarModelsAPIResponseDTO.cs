namespace CarSeer.Models.ExtAPI
{
    public class CarModelsAPIResponseDTO
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<CarModel> Results { get; set; }
    }

    public class CarModel : IMake, IModel
    {
        public int Make_ID { get; set; }
        public string Make_Name { get; set; }
        public int Model_ID { get; set; }
        public string Model_Name { get; set; }
    }

    interface IMake
    {
        public int Make_ID { get; set; }
        public string Make_Name { get; set; }
    }

    interface IModel
    {
        public int Model_ID { get; set; }
        public string Model_Name { get; set; }
    }
}
