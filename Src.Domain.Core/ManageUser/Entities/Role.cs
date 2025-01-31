using Src.Domain.Core.ManageUser.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageUser.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public RoleEnum Title { get; set; }
        public List<User> Users { get; set; }
    }
}
