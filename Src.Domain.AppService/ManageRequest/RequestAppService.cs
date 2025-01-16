using Microsoft.Identity.Client;
using Src.Domain.Core.ManageCar.Service;
using Src.Domain.Core.ManageRequest.AppService;
using Src.Domain.Core.ManageRequest.Entities;
using Src.Domain.Core.ManageRequest.Enums;
using Src.Domain.Core.ManageRequest.Service;
using Src.Domain.Core.ManageUser.Entities;
using Src.Domain.Core.ManageUser.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.AppService.ManageRequest
{
    public class RequestAppService : IRequestAppService
    {
        private readonly IRequestService _requestService;
        private readonly ICarService _carService;
        private readonly IUserService _userService;
        public RequestAppService(IRequestService requestService,ICarService carService,IUserService userService)
        {
            _requestService = requestService;
            _carService = carService;
            _userService = userService;
        }

        public Result AddLogRequest(string licenseplate)
        {
            int carid = _carService.GetCarId(licenseplate);
            return _requestService.AddLogRequest(carid);
        }

        public Result AddRequest(string nationalcode, string licenseplate)
        {
            var hasrequestinyear = _requestService.AnyRequestInYear(licenseplate);
            if (hasrequestinyear)
            {
                return new Result(false, "You have already submitted in this year once.");
            }
            else
            {
                var hasreachedlimit = _requestService.ReachedDailyLimit();
                if(hasreachedlimit.IsDone)
                {
                    return new Result(false, hasreachedlimit.Message);
                }
                else
                {
                    int userid = _userService.GetUserId(nationalcode);
                    int carid = _carService.GetCarId(licenseplate);
                    return _requestService.AddRequest(userid, carid);
                }
            }
        }

        public List<Request> GetAllRequests()
        {
            return _requestService.GetAll();
        }

        public Result UpdateRequest(int id, StatusEnum status)
        {
            var request = _requestService.GetRequest(id);
            _requestService.UpdateRequest(request, status);
            return new Result(true);
        }
    }
}
