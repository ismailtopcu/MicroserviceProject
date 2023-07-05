using MicroserviceProject.IdentityServer.Dtos;
using MicroserviceProject.IdentityServer.Models;
using MicroserviceProject.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MicroserviceProject.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var user = new ApplicationUser()
            {
                UserName = signUpDto.Username,
                Email = signUpDto.Email,
                City = signUpDto.City,
                Country = signUpDto.Country
            };
            var result = await _userManager.CreateAsync(user,signUpDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x=>x.Description).ToList(),400));
            }
            else
            {
                return NoContent();
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userClaimId = User.Claims.FirstOrDefault(x=>x.Type==JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaimId.Value);
            return Ok(new {Id=user.Id, username=user.UserName,email=user.Email,city=user.City,country=user.Country});
        }
    }
}
