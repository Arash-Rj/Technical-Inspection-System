using Src.Domain.Core.ManageUser.Entities;
using Src.Domain.Core.ManageUser.Repository;
using Src.Infra.DataBase.SqlServer.Ef.DbContexs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Infra.DataAccess.repos.Ef.ManageUser
{
    public class UserRepository : IUserRepository
    {
        private readonly AppointmentDbContext _appointmentDbContext;
        public UserRepository(AppointmentDbContext appointmentDbContext)
        {
            _appointmentDbContext = appointmentDbContext;
        }

        public bool DoesUserExists(string name, string nationalcode)
        {
           return _appointmentDbContext.Users.Any(u => u.Name.Equals(name) && u.NationalCode.Equals(nationalcode));
        }

        public User? Get(string nationalcode)
        {
            return _appointmentDbContext.Users.FirstOrDefault(u => u.NationalCode == nationalcode);
        }

        public List<User> GetAll()
        {
            return _appointmentDbContext.Users.ToList();
        }

        public int GetUserId(string nationalcode)
        {
            return _appointmentDbContext.Users.FirstOrDefault(u =>u.NationalCode.Equals(nationalcode)).Id;
        }
    }
}
