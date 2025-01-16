using Microsoft.EntityFrameworkCore;
using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageCar.Repository;
using Src.Domain.Core.ManageUser.Entities;
using Src.Infra.DataBase.SqlServer.Ef.DbContexs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Infra.DataAccess.repos.Ef.ManageCar
{
    public class CarRepository : ICarRepository
    {
        private AppointmentDbContext _appointmentDbContext;
        public CarRepository(AppointmentDbContext appointmentDbContext)
        {
            _appointmentDbContext = appointmentDbContext;
        }

        public Result Add(Car car)
        {
            try
            {
                _appointmentDbContext.Cars.Add(car);
                _appointmentDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true,"Car Successfully added.");
        }

        public Result Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCars()
        {
            return _appointmentDbContext.Cars.ToList();
        }

        public Car? GetCarByLicense(string carlicense)
        {
             return _appointmentDbContext.Cars.Include(c => c.User).FirstOrDefault(c => c.LicensePlate == carlicense);         
        }

        public int GetCarId(string LicensePlate)
        {
            return _appointmentDbContext.Cars.FirstOrDefault(c => c.LicensePlate.Equals(LicensePlate)).Id;
        }

        public Result Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
