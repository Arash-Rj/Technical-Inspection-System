using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageUser.Repository
{
    public interface IUserRepository
    {
        public Task<User?> Get(string nationalcode);
        public Task<List<User>> GetAll();
        public Task<int> GetUserId(string nationalcode);
        public Task<bool> DoesUserExists(string name,string nationalcode);
    }
}
