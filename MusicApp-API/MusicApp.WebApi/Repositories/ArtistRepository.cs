using Microsoft.EntityFrameworkCore;
using MusicApp.Entities.DB;
using MusicApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.WebApi
{
    public class ArtistRepository :  IArtistRepository
    {

        private MusicAppDBContext _context;
      
        public ArtistRepository(MusicAppDBContext context)
        {
            _context = context;
        }
        public async Task<List<Artist>> GetAllArtistsAsync()
        {
            try
            {
                return await _context.Artists.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Artist> GetArtistAsync(int id)
        {
            try
            {
                if (_context.Artists.Any(a => a.Id == id))
                {
                    Artist artist = await _context.Artists.SingleOrDefaultAsync(a => a.Id == id);
                    return artist;
                }
                else return null;
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
                return null;
            }
          

        }
        public async Task<List<Artist>> SearchArtistsAsync(string txtSearchInsert)
        {
            try
            {
                if (_context.Artists.Any(a => a.StageName.ToLower().StartsWith(txtSearchInsert.ToLower())))
                {
                    var query1 = _context.Artists.Where(a => a.StageName.ToLower().StartsWith(txtSearchInsert.ToLower())).Select(a => a);
                    List<Artist> artists = await query1.ToListAsync();
                    return artists;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
          

        }
        public async Task<int> AddNewArtistAsync(Artist artist)
        {
            string msg = "";
            if (!Regexes.NameRegex.IsMatch(artist.LastName))
            {
                msg += "First Name Shoulde Be Only Letters 2-10 Charachters";
            }
            if (!Regexes.NameRegex.IsMatch(artist.FirstName))
            {
                msg += "Last Name Shoulde Be Only Letters 2-10 Charachters";
            }
            if (msg != "")
            {
                Debug.WriteLine(msg);
                return -1;
            }
            else
            {
                try
                {
                    await _context.Artists.AddAsync(artist);
                    await _context.SaveChangesAsync();
                    return artist.Id;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.InnerException.Message);
                    return -1;
                }
            }

        }

        public async Task<string> AddOrRemoveArtistsUserAsync(int artistId, string userEmail)
        {
            try
            {
                var user = await _context.Users.SingleAsync(u => u.Email == userEmail);
                var ArtistsUser = await _context.ArtistsUsers.SingleOrDefaultAsync(au =>
                    au.ArtistId == artistId && au.UserId == user.Id);

                if (ArtistsUser == null)
                {
                    var result = await _context.ArtistsUsers.AddAsync(
                            new ArtistsUser { ArtistId = artistId, UserId = user.Id }
                            );
                }
                else
                {
                    _context.ArtistsUsers.Remove(ArtistsUser);
                }
                await _context.SaveChangesAsync();
                return "";
            }
            catch (Exception)
            {
                return "Something Went Wrong...";
            }
          
        }

        public async Task<bool> UpdateToDataBaseAsync(Artist artist)
        {
            string msg = "";
            if (!Regexes.NameRegex.IsMatch(artist.LastName))
            {
                msg += "First Name Shoulde Be Only Letters 2-10 Charachters";
            }
            if (!Regexes.NameRegex.IsMatch(artist.FirstName))
            {
                msg += "Last Name Shoulde Be Only Letters 2-10 Charachters";
            }
            if (msg != "")
            {
                Debug.WriteLine(msg);
                return false;
            }
            else
            {

                try
                {
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return false;
                }
            }

        }
        public async Task<List<Artist>> GetLikedArtistsAsync(string userEmail)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == userEmail);
                var query = _context.ArtistsUsers.Where(a => a.UserId == user.Id).Include(a => a.Artist);
                return await query.Select(au => au.Artist).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<int> GetFollowersCount(int artistId)
        {
            try
            {
                return await _context.ArtistsUsers.CountAsync(au => au.ArtistId == artistId);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public async Task<Coutry> GetArtistCoutryAsync(int artistId)
        {
            try
            {
                var artist = await _context.Artists.Where(a => a.Id == artistId).Include(a => a.Coutry).FirstOrDefaultAsync();

                if (artist == null)
                {
                    return null;
                }
                return artist.Coutry;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<bool> CheckArtistUserAsync(int artistId, string userEmail)
        {
            try
            {
                var user = await _context.Users.SingleAsync(u => u.Email == userEmail);
                var result = await _context.ArtistsUsers.SingleOrDefaultAsync( au =>
                     au.ArtistId == artistId && au.UserId == user.Id
                );
                if (result == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
