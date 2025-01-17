using Src.Domain.Core.ManageUser.Entities;
using Src.Domain.Core.ManageUser.Enums;
using Src.Domain.Core.ManageUser.Repository;
using Src.Domain.Core.ManageUser.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Service.ManageUser
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {            
            _userRepository = userRepository;
        }

        public Result DoesUserExists(string name, string nationalcode)
        {
           var doesexist =  _userRepository.DoesUserExists(name, nationalcode);
            if(doesexist)
            {
                return new Result(true);
            }
            else
            {
                return new Result(false, "The user could'nt be found. Name or national code is wrong.");
            }
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User? GetUser(string naitonalcode)
        {
            return _userRepository.Get(naitonalcode);
        }

        public int GetUserId(string nationalcode)
        {
            return _userRepository.GetUserId(nationalcode);
        }

        public Result IsUserAdmin(RoleEnum? role)
        {
            if(role == RoleEnum.Admin)
            {
                return new Result(true);
            }
            else
            {
                return new Result(false,"The user is not admin.You can not login as admin.");
            }
        }
    }
}
