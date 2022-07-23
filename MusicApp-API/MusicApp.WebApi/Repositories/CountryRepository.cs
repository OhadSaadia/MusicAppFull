using MusicApp.Entities.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.WebApi.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private MusicAppDBContext _context;

        public CountryRepository(MusicAppDBContext context)
        {
            _context = context;
        }

        public async Task<string> GetCountryNameAsync(int id)
        {
            try
            {
                var country = await _context.Coutries.FindAsync(id);
                return country.Name;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
