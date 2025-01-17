using Microsoft.AspNetCore.Mvc;
using Src.Domain.AppService.ManageCar;
using Src.Domain.Core.ManageCar.AppService;
using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageCar.Enums;
using Src.Domain.Core.ManageUser.AppService;
using Src.EndPoint.MVC.AppointmentSystem.Models;
using System.Runtime.CompilerServices;

namespace Src.EndPoint.MVC.AppointmentSystem.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarAppService _carAppService;
        private readonly IUserAppService _userAppService;
        public CarController(ICarAppService carAppService,IUserAppService userAppService)
        {
            _carAppService = carAppService;
            _userAppService = userAppService;

        }
        public IActionResult Index(int value)
        {
            var cars = _carAppService.GetAllCars();
            if (value == 0)
            {
                cars = cars.OrderByDescending(r => r.ManufactureDate).ToList();
            }
            else
            {
                cars = cars.OrderBy(r => r.ManufactureDate).ToList();
            }
            return View(cars);
        }
        public IActionResult Edit(int id)
        {
            var cardto = _carAppService.GetCarDtoById(id);
            var models = _carAppService.GetCarModels();
            CarModels.Models = models;
            return View(cardto);
        }
        [HttpPost]
        public IActionResult Edit(Cardto car)
        {
            var isdone = _carAppService.EditCar(car);
            if (!isdone.IsDone)
            {
                ViewBag.ErrorMessage = isdone.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var res = _carAppService.DeleteCar(id);
            if (!res.IsDone)
            {
                ViewBag.ErrorMessage = res.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            var users = _userAppService.GetAllUsers();
            var models = _carAppService.GetCarModels();
            CarModels.Models = models;
            return View(users);
        }
        [HttpPost]
        public IActionResult Create(int userid,string licenseplate,ModelEnum model,DateOnly manufacturedate, CompanyEnum company)
        {
            var res = _carAppService.CreateCar(userid, licenseplate, model, manufacturedate, company);
            if (!res.IsDone)
            {
                ViewBag.ErrorMessage = res.Message;
                return View();
            }
            TempData["SuccessMessage"] = res.Message;
            return RedirectToAction("Index", "Home");
        }
    }
}
