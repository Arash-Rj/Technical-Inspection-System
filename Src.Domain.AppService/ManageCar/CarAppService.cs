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

        public List<ModelEnum> GetCarModels()
        {
            return _carService.GetCarModels();
        }
    }
}
