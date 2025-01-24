using Src.Domain.Core.Configs;
using Src.Domain.Core.ManageRequest.Entities;
using Src.Domain.Core.ManageRequest.Enums;
using Src.Domain.Core.ManageRequest.Repository;
using Src.Domain.Core.ManageRequest.Service;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Service.ManageRequest
{
    public class RequestService: IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly DayLimitaions _dayLimitaions;
        public RequestService(IRequestRepository requestRepository,DayLimitaions dayLimitaions)
        {            
            _requestRepository = requestRepository;
            _dayLimitaions = dayLimitaions;
        }

        public Result AddLogRequest(int carid)
        {
            var requestlog = new OldCarRequest()
            {
               CarId = carid,
            };
            return _requestRepository.AddLog(requestlog);
        }

        public Result AddRequest(int userid , int carid)
        {
            var request = new Request()
            {
                UserId = userid,
                CarId = carid,
                RequestDate = DateTime.Now,
                Status = StatusEnum.Pending

            };
           return _requestRepository.Add(request);
        }

        public bool AnyRequestInYear(string licenseplate)
        {
            return _requestRepository.AnyRequestInYear(licenseplate);
        }

        public List<Request> GetAll()
        {
            return _requestRepository.GetAll();
        }

        public Request GetRequest(int userid)
        {
            return _requestRepository.GetById(userid);
        }

        public Result ReachedDailyLimit(DateTime requestdate)
        {
            int requestNo = _requestRepository.TodayRequestNo(requestdate);
            if(DateTime.Now.Day % 2 ==0)
            {
                if(requestNo < _dayLimitaions.EvenLimit)
                {
                    return new Result(false);
                }
                return new Result(true,$"Today's Dialy Request Limit has reached, please try again tomarrow. --Even days's limit: {_dayLimitaions.EvenLimit}");
            }
            else
            {
                if(requestNo < _dayLimitaions.OddLimit)
                {
                    return new Result(false);
                }
                return new Result(true, $"Today's Dialy Request Limit has reached, please try again tomarrow. --Odd days limit: {_dayLimitaions.OddLimit}");
            }
        }

        public Result UpdateRequest(Request request,StatusEnum status)
        {
            request.Status = status;
            _requestRepository.Update(request);
            return new Result(true);
        }
    }
}
