using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.AppService.ManageUser;
using Src.Domain.Core.ManageUser.AppService;
using Src.Domain.Core.ManageUser.Entities;
namespace Src.EndPoint.API.AppointmentSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [HttpPost]
        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(string username,string password,CancellationToken cancellationToken)
        {
           var result = await  _userAppService.Login(username, password,cancellationToken);
            return result;
        }
        public async Task<IdentityResult> Register(UserDto userDto,CancellationToken cancellationToken)
        {
            var result = await _userAppService.Register(userDto, cancellationToken);
            return result;
        }
    }
}
