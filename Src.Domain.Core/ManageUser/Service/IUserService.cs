using Src.Domain.Core.ManageUser.Entities;
using Src.Domain.Core.ManageUser.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageUser.Service
{
    public interface IUserService
    {
        public Task<User?> GetUser(string naitonalcode);
        public Task<int> GetUserId(string nationalcode);
        public Task<Result> DoesUserExists(string name,string nationalcode);
        public Result IsUserAdmin(RoleEnum? role);
        public Task<List<User>> GetAllUsers();
    }
}
