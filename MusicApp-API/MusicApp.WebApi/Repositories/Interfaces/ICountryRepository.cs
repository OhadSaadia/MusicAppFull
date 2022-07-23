using System.Threading.Tasks;

namespace MusicApp.WebApi.Repositories
{
    public interface ICountryRepository
    {
        Task<string> GetCountryNameAsync(int id);
    }
}