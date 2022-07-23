using MusicApp.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.WebApi
{
    public interface IArtistRepository
    {
        Task<int> AddNewArtistAsync(Artist artist);
        Task<List<Artist>> GetAllArtistsAsync();
        Task<Artist> GetArtistAsync(int id);
        Task<List<Artist>> SearchArtistsAsync(string txtSearchInsert);
        Task<bool> UpdateToDataBaseAsync(Artist artist);
        Task<Coutry> GetArtistCoutryAsync(int artistId);
        Task<List<Artist>> GetLikedArtistsAsync(string userEmail);
        Task<int> GetFollowersCount(int artistId);
        Task<string> AddOrRemoveArtistsUserAsync(int artistId, string userEmail);
        Task<bool> CheckArtistUserAsync(int artistId, string userEmail);

    }
}
