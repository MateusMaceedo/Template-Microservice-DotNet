using System.Threading.Tasks;

namespace Microservice.Catalog.Domain.Interfaces.Cache
{
    public interface ICache
    {
        Task<string> GetAsync(string key);
        Task SetAsync(string key, string value);
    }
}
