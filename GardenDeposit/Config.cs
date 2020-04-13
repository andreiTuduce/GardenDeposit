namespace GardenDeposit
{
    public class Config : IConfig
    {
        private readonly string connectionString = "mongodb://localhost:27017";
        public string ConnectionString
        {
            get { return connectionString; }
            set { }
        }
    }
}
