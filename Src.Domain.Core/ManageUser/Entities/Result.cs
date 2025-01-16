using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageUser.Entities
{
    public class Result
    {
        public string? Message { get; set; }
        public bool IsDone { get; set; }
        public Result(bool isDone,string? message=null)
        {
            IsDone = isDone;
            Message = message;
        }
    }
}
