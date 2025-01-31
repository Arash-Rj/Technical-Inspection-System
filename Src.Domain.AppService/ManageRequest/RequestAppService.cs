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
using System.ComponentModel.DataAnnotations;
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

        public async Task<Result> AddLogRequest(string licenseplate)
        {
            int carid = await _carService.GetCarId(licenseplate);
            return await _requestService.AddLogRequest(carid);
        }

        public async Task<Result> AddRequest(string nationalcode, string licenseplate, DateTime requestdate)
        {
            var hasrequestinyear = await _requestService.AnyRequestInYear(licenseplate);
            if (hasrequestinyear)
            {
                return new Result(false, "You have already submitted in this year once.");
            }
            else
            { 
                var hasreachedlimit = await _requestService.ReachedDailyLimit(requestdate);
                if(hasreachedlimit.IsDone)
                {
                    return new Result(false, hasreachedlimit.Message);
                }
                else
                {
                    int userid = await _userService.GetUserId(nationalcode);
                    int carid = await _carService.GetCarId(licenseplate);
                    return await _requestService.AddRequest(userid, carid);
                }
            }
        }

        public async Task<List<Request>> GetAllRequests()
        {
             return await _requestService.GetAll();
        }

        public async Task<Result> UpdateRequest(int id, StatusEnum status)
        {
            var request = await _requestService.GetRequest(id);
            await _requestService.UpdateRequest(request, status);
            return new Result(true);
        }
    }
}
