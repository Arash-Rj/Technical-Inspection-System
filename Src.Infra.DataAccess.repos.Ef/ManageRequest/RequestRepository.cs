using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.ManageRequest.Entities;
using Src.Domain.Core.ManageRequest.Enums;
using Src.Domain.Core.ManageRequest.Repository;
using Src.Domain.Core.ManageUser.Entities;
using Src.Infra.DataBase.SqlServer.Ef.DbContexs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Infra.DataAccess.repos.Ef.ManageRequest
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppointmentDbContext _appointmentDbContext;
        public RequestRepository(AppointmentDbContext appointmentDbContext)
        {            
            _appointmentDbContext = appointmentDbContext;
        }
        public async Task<Result> Add(Request request)
        {
            try
            {
               await _appointmentDbContext.AddAsync(request);
                _appointmentDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true);
        }

        public async Task<Result> AddLog(OldCarRequest request)
        {
            try
            {
              await  _appointmentDbContext.AddAsync(request);
                _appointmentDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true);
        }

        public async Task<bool> AnyRequestInYear(string licenseplate)
        {
            return await _appointmentDbContext.Requests.AnyAsync(r => r.Car.LicensePlate == licenseplate && r.RequestDate.Year == DateTime.Now.Year);
        }

        public async Task<List<Request>> GetAll()
        {
            return await _appointmentDbContext.Requests.Where(r => r.Status.Equals(StatusEnum.Pending)).Include(r => r.User).Include(r => r.Car).ToListAsync();
        }

        public async Task<Request> GetById(int id)
        {
            return await _appointmentDbContext.Requests.Include(r => r.User).Include(r => r.Car).FirstAsync(r => r.Id == id);   
        }

        public async Task<int> TodayRequestNo(DateTime requestdate)
        {
            return await _appointmentDbContext.Requests.Where(r => r.RequestDate.DayOfYear == requestdate.DayOfYear && r.Status == StatusEnum.Pending).CountAsync();
        }

        public async Task<bool> Update(Request request)
        {
            _appointmentDbContext.Update(request);
           await _appointmentDbContext.SaveChangesAsync();
            return true;
        }
    }
}
