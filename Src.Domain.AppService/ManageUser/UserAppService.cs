using Src.Domain.Core.ManageUser.AppService;
using Src.Domain.Core.ManageUser.Entities;
using Src.Domain.Core.ManageUser.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.AppService.ManageUser
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public Result AdminLogin(string name, string natnionalcode)
        {
           var doesexist =  _userService.DoesUserExists(name, natnionalcode);
            if (doesexist.IsDone)
            {
                var user = _userService.GetUser(natnionalcode);
                if (user != null)
                {
                   var isadmin = _userService.IsUserAdmin(user.Role);
                    if(isadmin.IsDone)
                    {
                        OnlineAdmin.User = user;
                        return new Result(true);
                    }
                    else
                    {
                        return isadmin;
                    }
                }
                else
                {
                    return new Result(false, "Could'nt get user.An Error occoured while trying to obtian user.");
                }
            }
            else
            {
                return doesexist;
            }
        }

        public Result CanRequest(User user)
        {
           var User =  _userService.GetUser(user.NationalCode);
            if (User == null)
            {
                return new Result(false,$"User with national code {user.NationalCode} Could not be found!");
            }
            else
            {
                if(user.Name == User.Name)
                {
                    if(user.PhoneNumber == User.PhoneNumber)
                    {
                        return new Result(true);
                    }
                    else
                    {
                        return new Result(false, "this phone number does not belong to the given national code.");
                    }
                }
                else
                {
                    return new Result(false, "User's name is wrong.");
                }
            }
        }
    }
}
