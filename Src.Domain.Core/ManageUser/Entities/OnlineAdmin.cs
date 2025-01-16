using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageUser.Entities
{
    public class OnlineAdmin
    {
        public static User? User;
        public OnlineAdmin(User user)
        {
            User = user;
        }
    }
}
