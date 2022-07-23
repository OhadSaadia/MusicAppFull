using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MusicApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
       
        public GenresController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;        
        }


        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genreRepository.GetAllGenresAsync();
            if (genres != null && genres.Count > 0)
            {
                return Ok(genres);
            }
            return NotFound();
        }


        [HttpGet("search")]
        public async Task<IActionResult> GetGenreByName([FromQuery] string genrename)
        {
            var genre = await _genreRepository.GetGenreAsync(genrename);
            if (genre != null)
            {
                return Ok(genre);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById([FromRoute] int id)
        {
            var genreName = await _genreRepository.GetGenreNameAsync(id);
            if (genreName != null)
            {
                return Ok(genreName);
            }
            return NotFound("Genre Didn't Found");
        }
    }
}
