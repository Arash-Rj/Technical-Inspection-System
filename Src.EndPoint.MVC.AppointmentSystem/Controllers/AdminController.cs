using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.ManageRequest.AppService;
using Src.Domain.Core.ManageRequest.Enums;
using Src.Domain.Core.ManageRequest.Repository;
using Src.Domain.Core.ManageUser.AppService;
using System.Runtime.CompilerServices;

namespace Src.EndPoint.MVC.AppointmentSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserAppService userAppService;
        private readonly IRequestAppService requestAppService;
        public AdminController(IUserAppService userAppService, IRequestAppService requestAppService)
        {
            this.userAppService = userAppService;
            this.requestAppService = requestAppService;
        }
        public IActionResult Index(int value)
        {
            var requests = requestAppService.GetAllRequests();
            if(value == 0)
            {
               requests = requests.OrderByDescending(r=> r.RequestDate).ToList();
            }
            else
            {
                requests = requests.OrderBy(r => r.RequestDate).ToList();
            }
            return View(requests);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string name,int naitonalcode)
        {
            var nationalcode1 = naitonalcode.ToString();
            var isloggedin =  userAppService.AdminLogin(name, nationalcode1);
            if (!isloggedin.IsDone)
            {
                ViewBag.ErrorMessage = isloggedin.Message;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ChangeRequestStat(int id,StatusEnum status)
        {
            requestAppService.UpdateRequest(id, status);
            return RedirectToAction("Index");
        }
    }
}
