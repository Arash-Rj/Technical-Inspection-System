using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> DoesUserExists(string name, string nationalcode)
        {
           return await _appointmentDbContext.Users.AnyAsync(u => u.Name.Equals(name) && u.NationalCode.Equals(nationalcode));
        }

        public async Task<User?> Get(string nationalcode)
        {
            return await _appointmentDbContext.Users.FirstOrDefaultAsync(u => u.NationalCode == nationalcode);
        }

        public async Task<List<User>> GetAll()
        {
            return await _appointmentDbContext.Users.ToListAsync();
        }

        public async Task<int> GetUserId(string nationalcode)
        {
            var user = await  _appointmentDbContext.Users.FirstOrDefaultAsync(u =>u.NationalCode.Equals(nationalcode));
            return user.Id;
        }
    }
}
