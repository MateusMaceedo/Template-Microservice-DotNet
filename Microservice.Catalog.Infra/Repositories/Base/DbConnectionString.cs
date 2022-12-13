namespace Microservice.Catalog.Infra.Repositories.Base
{
    public interface IDbConnectionString
    {
        string? ConnectionString { get; set; }
        string? DatabaseName { get; set; }
    }

    public class DbConnectionString : IDbConnectionString
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
    }
}
