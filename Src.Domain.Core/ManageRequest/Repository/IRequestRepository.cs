using Src.Domain.Core.ManageRequest.Entities;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageRequest.Repository
{
    public interface IRequestRepository
    {
        public Task<Result> Add(Request request);
        public Task<bool> AnyRequestInYear(string licenseplate);
        public Task<int> TodayRequestNo(DateTime requestdate);
        public Task<List<Request>> GetAll();
        public Task<bool> Update(Request request);    
        public Task<Request> GetById(int id);
        public Task<Result> AddLog(OldCarRequest request);
    }
}
