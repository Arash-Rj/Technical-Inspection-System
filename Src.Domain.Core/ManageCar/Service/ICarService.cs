using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageCar.Enums;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageCar.Service
{
    public interface ICarService
    {
        public Task<List<ModelEnum>> GetCarModels();
        public Task<Car?> GetCarByLicense(string carlicense);
        public Result EvenOrOdd(CompanyEnum company);
        public Result IsOld(DateOnly manufactureDate);
        public Task<int> GetCarId(string LicensePlate);
        public Task<List<Car>> GetAllCars();
        public Task<Car> GetCarById(int id);
        public Task<Result> UpdateCar(Cardto cardto);
        public Task<Result> DeleteCar(int id);
        public Task<Result> AddCar(Car car);
    }
}
