using MusicApp.Entities;
using MusicApp.WebApi.DTO;
using System.Threading.Tasks;

namespace MusicApp.WebApi.Repositories
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> GetUserAsync(string email);
        Task<string> SignUpAsync(ApplicationUser applicationUser);
        Task<string> SignInAsync(SignInModel signInModel);
    }
}