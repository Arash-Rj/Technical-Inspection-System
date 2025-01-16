using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageRequest.Entities;
using Src.Domain.Core.ManageUser.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageUser.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public List<Car> Cars { get; set; } 
        public List<Request> Requests { get; set; }
        public RoleEnum? Role { get; set; }
    }
}
