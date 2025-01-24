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
        public Result Add(Request request)
        {
            try
            {
                _appointmentDbContext.Add(request);
                _appointmentDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true);
        }

        public Result AddLog(OldCarRequest request)
        {
            try
            {
                _appointmentDbContext.Add(request);
                _appointmentDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true);
        }

        public bool AnyRequestInYear(string licenseplate)
        {
            return _appointmentDbContext.Requests.Any(r => r.Car.LicensePlate == licenseplate && r.RequestDate.Year == DateTime.Now.Year);
        }

        public List<Request> GetAll()
        {
            return _appointmentDbContext.Requests.Where(r => r.Status.Equals(StatusEnum.Pending)).Include(r => r.User).Include(r => r.Car).ToList();
        }

        public Request GetById(int id)
        {
            return _appointmentDbContext.Requests.Include(r => r.User).Include(r => r.Car).First(r => r.Id == id);   
        }

        public int TodayRequestNo(DateTime requestdate)
        {
            return _appointmentDbContext.Requests.Where(r => r.RequestDate.DayOfYear == requestdate.DayOfYear && r.Status == StatusEnum.Pending).Count();
        }

        public bool Update(Request request)
        {
            _appointmentDbContext.Update(request);
            _appointmentDbContext.SaveChanges();
            return true;
        }
    }
}
