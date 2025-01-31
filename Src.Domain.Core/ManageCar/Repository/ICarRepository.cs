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
        public Task<Car?> GetCarByLicense(string carlicense);
        public Task<List<Car>> GetAllCars();
        public Task<Result> Add(Car car);
        public Task<Result> Delete(Car car);
        public Task<Result> Update(Car car);
        public Task<int> GetCarId(string LicensePlate);
        public Task<Car> GetCarById(int id);
    }
}
