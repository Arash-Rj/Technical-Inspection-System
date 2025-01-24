using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.ManageCar.AppService;
using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageRequest.AppService;
using Src.Domain.Core.ManageRequest.Entities;
using Src.Domain.Core.ManageUser.AppService;
using Src.Domain.Core.ManageUser.Entities;
using Src.EndPoint.MVC.AppointmentSystem.Models;

namespace Src.EndPoint.MVC.AppointmentSystem.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestAppService requestAppservice;
        private readonly ICarAppService carAppService;
        private readonly IUserAppService userAppService;
        public RequestController(IRequestAppService requestAppservice, ICarAppService carAppService, IUserAppService userAppService)
        {
            this.requestAppservice = requestAppservice;
            this.carAppService = carAppService;
            this.userAppService = userAppService;
        }

        public IActionResult Index()
        {
       
            RequestModel requestModel = new RequestModel();
            var models = carAppService.GetCarModels();
            CarModels.Models = models.Distinct().ToList(); 
            return View(requestModel);
        }
        [HttpPost]
        public IActionResult Index(RequestModel requestmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(requestmodel);
            }
            else
            {
                #region mapping
                User user = new()
                {
                    Name = requestmodel.UserName,
                    NationalCode = requestmodel.NationalCode,
                    PhoneNumber = requestmodel.PhoneNumber,
                    Address = requestmodel.Address,
                };
                Car car = new()
                {
                    User = user,
                    LicensePlate = requestmodel.LicensePlate,
                    Company = requestmodel.CarCompany,
                    Model = requestmodel.CarModel
                };
                Request request = new Request()
                {
                    User = user,
                    Car = car,
                    RequestDate = requestmodel.RequestDate
                };
                #endregion mapping

                var iscar = carAppService.CanRequest(request.Car);
                if (iscar.IsDone)
                {
                    var isuser = userAppService.CanRequest(request.User);
                    if (isuser.IsDone)
                    {
                        var submit = requestAppservice.AddRequest(request.User.NationalCode, request.Car.LicensePlate,request.RequestDate);
                        if (submit.IsDone)
                        {

                        }
                        else
                        {
                            ViewBag.ErrorMessage = submit.Message;
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = isuser.Message;
                        return View();
                    }
                }
                else
                {
                    if (iscar.Message == "Your Car is more than 5 yearsold, only cars under the age of 5 can submit request.")
                    {
                        requestAppservice.AddLogRequest(request.Car.LicensePlate);
                        ViewBag.ErrorMessage = iscar.Message;
                        return View();
                    }
                    else
                    {
                        ViewBag.ErrorMessage = iscar.Message;
                        return View();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
