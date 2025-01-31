using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageCar.Enums;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageCar.AppService
{
    public interface ICarAppService
    {
        public Task<List<ModelEnum>> GetCarModels();
        public Task<Result> CanRequest(Car car);
        public Task<List<Car>> GetAllCars();
        public Task<Cardto> GetCarDtoById(int id);
        public Task<Result> EditCar(Cardto cardto);
        public Task<Result> DeleteCar(int id);
        public Task<Result> CreateCar(int userid,string license,ModelEnum model, DateOnly manufacturedate, CompanyEnum company);
    }
}
