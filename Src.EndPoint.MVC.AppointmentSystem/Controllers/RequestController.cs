using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.ManageCar.AppService;
using Src.Domain.Core.ManageRequest.AppService;
using Src.Domain.Core.ManageUser.AppService;
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
            Src.Domain.Core.ManageRequest.Entities.Request request = new Domain.Core.ManageRequest.Entities.Request();
            var models = carAppService.GetCarModels();
            CarModels.Models = models.Distinct().ToList(); ;
            return View(request);
        }
        [HttpPost]
        public IActionResult Index(Src.Domain.Core.ManageRequest.Entities.Request request)
        {
            request.Car.User = request.User;
            var iscar = carAppService.CanRequest(request.Car);
            if(iscar.IsDone) 
            {
               var isuser =  userAppService.CanRequest(request.User);
                if(isuser.IsDone)
                {
                    var submit = requestAppservice.AddRequest(request.User.NationalCode,request.Car.LicensePlate);
                    if(submit.IsDone)
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
                if(iscar.Message == "Your Car is more than 5 yearsold, only cars under the age of 5 can submit request.")
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
            return RedirectToAction("Index" , "Home");
        }
    }
}
