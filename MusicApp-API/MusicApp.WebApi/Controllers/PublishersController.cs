using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MusicApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublishers()
        {
            var publishers = await _publisherRepository.GetAllPublishersAsync();
            if (publishers != null && publishers.Count > 0)
            {
                return Ok(publishers);
            }
            return NotFound();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisher([FromRoute] int id)
        {
            var publisher = await _publisherRepository.GetPublisherAsync(id);
            if (publisher != null)
            {
                return Ok(publisher);
            }
            return NotFound();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetPublisher([FromQuery] string publishername)
        {
            var publisher = await _publisherRepository.GetPublisherAsync(publishername);
            if (publisher != null)
            {
                return Ok(publisher);
            }
            return NotFound();
        }
    }
}
