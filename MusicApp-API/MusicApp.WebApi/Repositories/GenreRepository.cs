using Microsoft.EntityFrameworkCore;
using MusicApp.Entities.DB;
using MusicApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.WebApi
{
    public class GenreRepository : IGenreRepository
    {
        private MusicAppDBContext _context;
        public GenreRepository(MusicAppDBContext context)
        {
            _context = context;
        }
        public async Task<List<Genre>> GetAllGenresAsync()
        {
            try
            {
                return await _context.Genres.Select(g => g).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }


        }
        public async Task<Genre> GetGenreAsync(string name)
        {
            try
            {
                return await _context.Genres.Where(g => g.Name == name).Select(g => g).SingleAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> GetGenreNameAsync(int id)
        {
            try
            {
                var genre = await _context.Genres.FindAsync(id);
                return genre.Name;
            }
            catch (Exception)
            { 
                return null;
            }
        }
        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
