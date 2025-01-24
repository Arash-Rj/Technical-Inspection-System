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
        public bool AnyRequestInYear(string licenseplate);
        public Result AddRequest(int userid, int carid);
        public Result ReachedDailyLimit(DateTime requestdate);
        public List<Request> GetAll();
        public Result UpdateRequest(Request request,StatusEnum status);
        public Request GetRequest(int userid);
        public Result AddLogRequest(int carid);
    }
}
