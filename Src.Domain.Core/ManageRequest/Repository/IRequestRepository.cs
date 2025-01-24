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
        public Result Add(Request request);
        public bool AnyRequestInYear(string licenseplate);
        public int TodayRequestNo(DateTime requestdate);
        public List<Request> GetAll();
        public bool Update(Request request);    
        public Request GetById(int id);
        public Result AddLog(OldCarRequest request);
    }
}
