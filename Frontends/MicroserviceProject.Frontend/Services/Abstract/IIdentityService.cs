using MicroserviceProject.Frontend.Models;
using MicroserviceProject.Shared.Dtos;
using System.Threading.Tasks;

namespace MicroserviceProject.Frontend.Services.Abstract
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInInput signInInput);
    }
}
