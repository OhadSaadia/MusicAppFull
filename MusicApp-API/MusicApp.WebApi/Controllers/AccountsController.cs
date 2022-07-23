
using Microsoft.AspNetCore.Mvc;
using MusicApp.Entities;
using MusicApp.WebApi.DTO;
using System.Threading.Tasks;
using MusicApp.WebApi.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace MusicApp.WebApi.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountsController(IAccountRepository accountRepository,
                                    IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> GetUser([FromQuery] string useremail)
        {
            var result = await _accountRepository.GetUserAsync(useremail);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]SignUpModel signUpModel)
        {
            var user = _mapper.Map<ApplicationUser>(signUpModel);
            var result = await _accountRepository.SignUpAsync(user);
            if (string.IsNullOrEmpty(result))
            {
                return NoContent();
            }
            return Ok(result);
        }


        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody]SignInModel signInModel)
        {
            var result = await _accountRepository.SignInAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return NoContent();
            }
            return Ok(result);
        }

    }
}
