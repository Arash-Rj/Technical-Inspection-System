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
        public User? Get(string nationalcode);
        public List<User> GetAll();
        public int GetUserId(string nationalcode);
        public bool DoesUserExists(string name,string nationalcode);
    }
}
