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

        public async Task<Result> Add(Car car)
        {
            try
            {
               await _appointmentDbContext.Cars.AddAsync(car);
               await _appointmentDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
            return new Result(true,"Car Successfully added.");
        }

        public async Task<Result> Delete(Car car)
        {
             _appointmentDbContext.Cars.Remove(car);
           await _appointmentDbContext.SaveChangesAsync();
            return new Result(true);
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await _appointmentDbContext.Cars.Include(c => c.User).ToListAsync();
        }

        public async Task<Car> GetCarById(int id)
        {
            return await _appointmentDbContext.Cars.FirstAsync(c => c.Id.Equals(id));
        }

        public async Task<Car?> GetCarByLicense(string carlicense)
        {
             return await _appointmentDbContext.Cars.Include(c => c.User).FirstOrDefaultAsync(c => c.LicensePlate == carlicense);         
        }

        public async Task<int> GetCarId(string LicensePlate)
        {
            var car = await _appointmentDbContext.Cars.FirstOrDefaultAsync(c => c.LicensePlate.Equals(LicensePlate));
            return car.Id;
        }

        public async Task<Result> Update(Car car)
        {
            _appointmentDbContext.Update(car);
           await _appointmentDbContext.SaveChangesAsync();
            return new Result(true);
        }
    }
}
