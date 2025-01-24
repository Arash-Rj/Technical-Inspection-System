using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageRequest.Enums;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageRequest.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public DateTime RequestDate { get; set; }
        public StatusEnum Status { get; set; }

   

    }
}
