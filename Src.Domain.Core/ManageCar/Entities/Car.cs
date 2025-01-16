using Src.Domain.Core.ManageCar.Enums;
using Src.Domain.Core.ManageRequest.Entities;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageCar.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public CompanyEnum Company { get; set; }    
        public ModelEnum Model { get; set; }
        public DateOnly ManufactureDate { get; set; }
        public string LicensePlate { get; set; }
        public List<Request> Requests { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
