using Src.Domain.Core.ManageCar.AppService;
using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageCar.Enums;
using Src.Domain.Core.ManageCar.Service;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.AppService.ManageCar
{
    public class CarAppService : ICarAppService
    {
        private readonly ICarService _carService;
        public CarAppService(ICarService carService) 
        {
            _carService = carService;
        }

        public async Task<Result> CanRequest(Car car)
        {
            var Car = await _carService.GetCarByLicense(car.LicensePlate);
            if (Car == null)
            {
                return new Result(false,"No Car was found with the given Specifications!!!");
            }
            else
            {
                if(car.User.NationalCode == Car.User.NationalCode && car.User.Name== Car.User.Name )
                {
                    if(Car.Company == Car.Company && car.Model == Car.Model)
                    {
                        var isdone =  _carService.EvenOrOdd(car.Company);
                        if(isdone.IsDone)
                        {
                           var isold =   _carService.IsOld(Car.ManufactureDate);
                            if (isold.IsDone)
                            {
                                return new Result(false,isold.Message);
                            }
                            else
                            {
                                return new Result(true);
                            }
                        }
                        else
                        {
                            return isdone;
                        }
                    }
                    else
                    {
                        return new Result(false, "The Model or Company does not match");
                    }
                }
                else
                {
                    return new Result(false, $"The Car does not belong to the Naitonal code {car.User.NationalCode}");
                }
            }
        }

        public async Task<Result> CreateCar(int userid, string license, ModelEnum model, DateOnly manufacturedate, CompanyEnum company)
        {
            Car car = new Car()
            {
                UserId = userid,
                LicensePlate = license,
                Model = model,
                Company = company,
                ManufactureDate = manufacturedate
            };
           return await _carService.AddCar(car);
        }

        public async Task<Result> DeleteCar(int id)
        {
            return await _carService.DeleteCar(id);
        }

        public async Task<Result> EditCar(Cardto cardto)
        {
            return await _carService.UpdateCar(cardto);
        }

        public async Task<List<Car>> GetAllCars()
        {

            var cars = await _carService.GetAllCars();
            cars.ForEach(car => car.User = null);
            return cars;
        }

        public async Task<Cardto> GetCarDtoById(int id)
        {
            var car = await _carService.GetCarById(id);
            Cardto cardto = new Cardto()
            {
                Id = id,
                LicensePlate = car.LicensePlate,
                Company = car.Company,
                Model = car.Model,
            };
            return cardto;
        }

        public async Task<List<ModelEnum>> GetCarModels()
        {
            return await _carService.GetCarModels();
        }
    }
}
