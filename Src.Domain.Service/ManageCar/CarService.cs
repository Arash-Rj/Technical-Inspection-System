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

        public async Task<Result> AddCar(Car car)
        {
            var cars = await carRepository.GetAllCars();
            bool isrepetitive = cars.Any(c => c.LicensePlate.Equals(car.LicensePlate));
            if (isrepetitive )
            {
                return new Result(false, "License plate already exists.");
            }
            carRepository.Add(car);
            return new Result(true,"Car Is Successfully Added.");
        }

        public async Task<Result> DeleteCar(int id)
        {
            var car = await carRepository.GetCarById(id);
            return await carRepository.Delete(car);
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

        public async Task<List<Car>> GetAllCars()
        {
            return await carRepository.GetAllCars();
        }

        public async Task<Car> GetCarById(int id)
        {
            return await carRepository.GetCarById(id);
        }

        public async Task<Car?> GetCarByLicense(string carlicense)
        {
            return await carRepository.GetCarByLicense(carlicense);
        }

        public async Task<int> GetCarId(string LicensePlate)
        {
            return await carRepository.GetCarId(LicensePlate);
        }

        public async Task<List<ModelEnum>> GetCarModels()
        {
            var models = new List<ModelEnum>();
            var cars = await carRepository.GetAllCars();
            foreach(var car in cars)
            {
                models.Add(car.Model);
            }
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

        public async Task<Result> UpdateCar(Cardto cardto)
        {
            var car = await carRepository.GetCarById(cardto.Id);
            car.LicensePlate = cardto.LicensePlate;
            car.Model = cardto.Model;
            car.Company = cardto.Company;
            return  await carRepository.Update(car);
        }
    }
}
