
using UsersProject.Core.Interfaces;
using UsersProject.Services.Helpers;

namespace UsersProject.Controllers
{
    public class UserController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
