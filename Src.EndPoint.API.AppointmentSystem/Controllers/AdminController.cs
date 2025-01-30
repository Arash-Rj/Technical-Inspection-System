using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.ManageRequest.AppService;
using Src.Domain.Core.ManageRequest.Entities;
using Src.Domain.Core.ManageRequest.Enums;
using Src.Domain.Core.ManageUser.AppService;
using Src.Domain.Core.ManageUser.Entities;

namespace Src.EndPoint.API.AppointmentSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserAppService userAppService;
        private readonly IRequestAppService requestAppService;
        public AdminController(IUserAppService userAppService, IRequestAppService requestAppService)
        {
            this.userAppService = userAppService;
            this.requestAppService = requestAppService;
        }

        [HttpGet("Get-All-Requests")]
        public  List<RequestDto> GetAll(int Order)
        {
             var reqs =  requestAppService.GetAllRequests();
            var requestdtos = new List<RequestDto>();
            foreach (var req in reqs)
            {
                var reqdto = new RequestDto()
                {
                   Id = req.Id,
                   Username = req.User.Name,
                   NationalCode = req.User.NationalCode,
                   PhoneNumber = req.User.PhoneNumber,
                   CarCompany = req.Car.Company,
                   CarModel = req.Car.Model,
                   CarManufactureDate = req.Car.ManufactureDate,
                   RequestDate = req.RequestDate,
                   Status = req.Status,
                }; 
                requestdtos.Add(reqdto);
            }
            if (Order == 0)
            {
                requestdtos = requestdtos.OrderByDescending(r => r.RequestDate).ToList();
            }
            else
            {
                requestdtos = requestdtos.OrderBy(r => r.RequestDate).ToList();
            }
            return requestdtos;
        }

        [HttpPost("Login")]
        public Result Login(string name, int nationalcode)
        {
            var nationalcode1 = nationalcode.ToString();
            var isloggedin = userAppService.AdminLogin(name, nationalcode1);
            return isloggedin;
        }
        [HttpPost("Change-Request-Status")]
        public Result ChangeRequestStat(int id, StatusEnum status)
        {
            return requestAppService.UpdateRequest(id, status);
        }
        [HttpGet("Get-All-Users")]
        public List<User> GetUsers()
        {
            return userAppService.GetAllUsers();
        }
    }
}
