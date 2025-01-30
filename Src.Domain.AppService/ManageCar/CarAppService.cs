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

        public Result CanRequest(Car car)
        {
            var Car = _carService.GetCarByLicense(car.LicensePlate);
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
                        var isdone = _carService.EvenOrOdd(car.Company);
                        if(isdone.IsDone)
                        {
                           var isold =  _carService.IsOld(Car.ManufactureDate);
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

        public Result CreateCar(int userid, string license, ModelEnum model, DateOnly manufacturedate, CompanyEnum company)
        {
            Car car = new Car()
            {
                UserId = userid,
                LicensePlate = license,
                Model = model,
                Company = company,
                ManufactureDate = manufacturedate
            };
           return _carService.AddCar(car);
        }

        public Result DeleteCar(int id)
        {
            return _carService.DeleteCar(id);
        }

        public Result EditCar(Cardto cardto)
        {
            return _carService.UpdateCar(cardto);
        }

        public List<Car> GetAllCars()
        {

            var cars = _carService.GetAllCars();
            cars.ForEach(car => car.User = null);
            return cars;
        }

        public Cardto GetCarDtoById(int id)
        {
            var car = _carService.GetCarById(id);
            Cardto cardto = new Cardto()
            {
                Id = id,
                LicensePlate = car.LicensePlate,
                Company = car.Company,
                Model = car.Model,
            };
            return cardto;
        }

        public List<ModelEnum> GetCarModels()
        {
            return _carService.GetCarModels();
        }
    }
}
