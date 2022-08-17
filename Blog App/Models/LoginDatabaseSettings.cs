namespace Blog_App.Models
{
    public class LoginDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string LoginCollectionName { get; set; } = null!;

    }
}
