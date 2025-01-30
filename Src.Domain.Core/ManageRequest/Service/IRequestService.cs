using Src.Domain.Core.ManageRequest.Entities;
using Src.Domain.Core.ManageRequest.Enums;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageRequest.Service
{
    public interface IRequestService
    {
        public Task<bool> AnyRequestInYear(string licenseplate);
        public Task<Result> AddRequest(int userid, int carid);
        public Task<Result> ReachedDailyLimit(DateTime requestdate);
        public Task<List<Request>> GetAll();
        public Task<Result> UpdateRequest(Request request,StatusEnum status);
        public Task<Request> GetRequest(int userid);
        public Task<Result> AddLogRequest(int carid);
    }
}
