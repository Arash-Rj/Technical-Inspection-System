using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageUser.AppService
{
    public interface IUserAppService
    {
        public Result CanRequest(User user);
        public Result AdminLogin(string name, string natnionalcode);
        public List<User> GetAllUsers();
    }
}
