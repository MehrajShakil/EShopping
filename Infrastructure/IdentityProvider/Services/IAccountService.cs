using System.Threading.Tasks;
using IdentityProvider.Dtos;
using IdentityServerHost.Quickstart.UI;

namespace IdentityProvider.Services;

public interface IAccountService
{
    public Task<UserCreatedResult> CreateUserAsync(UserRegistrationRequest request);
    public Task<UserLoginResult> UserLoginAsync(LoginInputModel loginCred);
}
