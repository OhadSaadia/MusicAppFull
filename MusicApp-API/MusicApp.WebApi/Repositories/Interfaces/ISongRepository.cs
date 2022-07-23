using MusicApp.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApp.WebApi
{
    public interface ISongRepository
    {

        #region Get

        Task<List<Song>> GetAllAsync();
        Task<Song> GetSongAsync(int id);
        Task<List<Song>> SearchSongAsync(string songName);
        Task<List<Song>> GetAlbumSongsAsync(int albumId);
        Task<List<Song>> GetLikedSongAsync(string userEmail);
        Task<List<Song>> GetListeningHistoryAsync(string userEmail);
        Task<List<Song>> GetArtistSongsAsync(int artistId);

        #endregion

        #region Add

        Task<string> AddSongToSongLogAsync(int songId,string userEmail);
        Task<string> AddOrRemoveSongToLikesAsync(int songId, string userEmail);
        Task<int> AddToDataBaseAsync(Song song);
        Task<bool> CheckSongsUserAsync(int songId, string userEmail);

        #endregion

        #region Delete

        Task<bool> DeleteAsync(int songID);
        Task<string> RemoveSongFromLikesAsync(int songId, string userEmail);
     
        #endregion
        
        Task<bool> UpdateToDataBaseAsync(Song song);

        Task DisposeAsync();
        Task<List<Song>> Get10TopPlayedAsync();
        Task<List<Song>> Get10MostLikedAsync();
        Task<List<Song>> Get10RandomAsync();
    }
}