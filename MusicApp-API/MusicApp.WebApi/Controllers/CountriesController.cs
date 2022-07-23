
using Microsoft.AspNetCore.Mvc;
using MusicApp.WebApi.Repositories;
using System.Threading.Tasks;

namespace MusicApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryName([FromRoute] int id)
        {
            var result = await _countryRepository.GetCountryNameAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Country Didn't Found");
        }
    }
}
