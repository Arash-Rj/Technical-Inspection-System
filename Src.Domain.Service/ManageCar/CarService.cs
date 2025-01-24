using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageCar.Enums;
using Src.Domain.Core.ManageCar.Repository;
using Src.Domain.Core.ManageCar.Service;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Service.ManageCar
{
    public class CarService : ICarService
    {
        private readonly ICarRepository carRepository;
        public CarService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public Result AddCar(Car car)
        {
            var cars = carRepository.GetAllCars();
            bool isrepetitive = cars.Any(c => c.LicensePlate.Equals(car.LicensePlate));
            if (isrepetitive )
            {
                return new Result(false, "License plate already exists.");
            }
            carRepository.Add(car);
            return new Result(true,"Car Is Successfully Added.");
        }

        public Result DeleteCar(int id)
        {
            var car = carRepository.GetCarById(id);
            return carRepository.Delete(car);
        }

        public Result EvenOrOdd(CompanyEnum company)
        {
            if(DateTime.Now.DayOfYear % 2  == 0)
            {
                if(company == CompanyEnum.IranKhodro)
                {
                    return new Result(true);
                }
                else
                {
                    return new Result(false,$"Only {CompanyEnum.IranKhodro} cars can Submit request on even days.");
                }
            }
            else
            {
                if (company == CompanyEnum.saipa)
                {
                    return new Result(true);
                }
                else
                {
                    return new Result(false, $"Only {CompanyEnum.saipa} cars can Submit request on odd days.");
                }
            }
        }

        public List<Car> GetAllCars()
        {
            return carRepository.GetAllCars();
        }

        public Car GetCarById(int id)
        {
            return carRepository.GetCarById(id);
        }

        public Car? GetCarByLicense(string carlicense)
        {
            return carRepository.GetCarByLicense(carlicense);
        }

        public int GetCarId(string LicensePlate)
        {
            return carRepository.GetCarId(LicensePlate);
        }

        public List<ModelEnum> GetCarModels()
        {
            var models = new List<ModelEnum>();
            carRepository.GetAllCars().ForEach(car => { models.Add(car.Model); });
            return models;
        }

        public Result IsOld(DateOnly manufactureDate)
        {
            
            if (manufactureDate.AddDays(365*5) < DateOnly.FromDateTime(DateTime.Now))
            {
                return new Result(true,"Your Car is more than 5 yearsold, only cars under the age of 5 can submit request.");
            }
            else
            {
                return new Result(false);
            }
        }

        public Result UpdateCar(Cardto cardto)
        {
            var car = carRepository.GetCarById(cardto.Id);
            car.LicensePlate = cardto.LicensePlate;
            car.Model = cardto.Model;
            car.Company = cardto.Company;
            return carRepository.Update(car);
        }
    }
}
