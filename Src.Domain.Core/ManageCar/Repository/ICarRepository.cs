using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageCar.Repository
{
    public interface ICarRepository
    {
        public Car? GetCarByLicense(string carlicense);
        public List<Car> GetAllCars();
        public Result Add(Car car);
        public Result Delete(Car car);
        public Result Update(Car car);
        public int GetCarId(string LicensePlate);
        public Car GetCarById(int id);
    }
}
