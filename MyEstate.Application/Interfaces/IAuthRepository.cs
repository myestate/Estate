using System.Threading.Tasks;

namespace MyEstate.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<Domain.Entities.User> Register(Domain.Entities.User user, string password);

        Task<Domain.Entities.User> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}