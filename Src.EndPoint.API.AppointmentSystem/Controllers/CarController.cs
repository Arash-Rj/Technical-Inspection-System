using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.Configs;
using Src.Domain.Core.ManageCar.AppService;
using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageCar.Enums;
using Src.Domain.Core.ManageUser.AppService;
using Src.Domain.Core.ManageUser.Entities;
using Src.EndPoint.API.AppointmentSystem.Model;

namespace Src.EndPoint.API.AppointmentSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly ICarAppService _carAppService;
        private readonly IUserAppService _userAppService;
        private readonly ApiKey ApiKey;
        public CarController(ICarAppService carAppService, IUserAppService userAppService,ApiKey apiKey)
        {
            _carAppService = carAppService;
            _userAppService = userAppService;
            ApiKey = apiKey;
        }
        [HttpGet("AllCars")]
        public List<Car> GetAll(int Order, [FromHeader] string apikey)
        {
            if(apikey != ApiKey.Apikey)
            {
                throw new Exception("You do not have access to this Api.");
            }
            var cars = _carAppService.GetAllCars();
            if (Order == 0)
            {
                cars = cars.OrderByDescending(r => r.ManufactureDate).ToList();
            }
            else
            {
                cars = cars.OrderBy(r => r.ManufactureDate).ToList();
            }
            return cars;
        }
        [HttpGet("Get-Preview")]
        public Cardto Edit(int id,[FromHeader]string apikey)
        {
            if (apikey != ApiKey.Apikey)
            {
                throw new Exception("You do not have access to this Api.");
            }
            var cardto = _carAppService.GetCarDtoById(id);
            var models = _carAppService.GetCarModels();
            CarModels.Models = models;
            return cardto;
        }
        [HttpPost("Edit-Car")]
        public Result Edit(Cardto car, [FromHeader] string apikey)
        {
            if (apikey != ApiKey.Apikey)
            {
                throw new Exception("You do not have access to this Api.");
            }
            var isdone = _carAppService.EditCar(car);
            return isdone;
        }
        [HttpGet("Delete-Car")]
        public Result Delete(int id, [FromHeader] string apikey)
        {
            if (apikey != ApiKey.Apikey)
            {
                throw new Exception("You do not have access to this Api.");
            }
            var res = _carAppService.DeleteCar(id);
            return res;
        }
        [HttpGet("Car-Models")]
        public List<ModelEnum> GetCarModels([FromHeader] string apikey)
        {
            if (apikey != ApiKey.Apikey)
            {
                throw new Exception("You do not have access to this Api.");
            }
            var models = _carAppService.GetCarModels();
            CarModels.Models = models;
            return models;
        }
        [HttpPost("Add-Car")]
        public Result Create(int userid, string licenseplate, ModelEnum model, DateOnly manufacturedate, CompanyEnum company, [FromHeader] string apikey)
        {
            if (apikey != ApiKey.Apikey)
            {
                throw new Exception("You do not have access to this Api.");
            }
            var res = _carAppService.CreateCar(userid, licenseplate, model, manufacturedate, company);
            return res;
        }
    }
}
