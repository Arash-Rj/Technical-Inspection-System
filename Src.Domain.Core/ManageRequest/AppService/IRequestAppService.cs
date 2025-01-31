using Src.Domain.Core.ManageRequest.Entities;
using Src.Domain.Core.ManageRequest.Enums;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageRequest.AppService
{
    public interface IRequestAppService
    {
        public Task<Result> AddRequest(string nationalcode, string licenseplate,DateTime requestdate);
        public Task<List<Request>> GetAllRequests();
        public Task<Result> UpdateRequest(int id,StatusEnum status);
        public Task<Result> AddLogRequest(string licenseplate);
    }
}
