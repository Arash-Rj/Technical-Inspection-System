using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageCar.Enums;
using Src.Domain.Core.ManageRequest.Enums;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageRequest.Entities
{
    public class RequestDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public ModelEnum CarModel { get; set; }
        public CompanyEnum CarCompany { get; set; }
        public DateOnly CarManufactureDate { get; set; }
        public DateTime RequestDate { get; set; }
        public StatusEnum Status { get; set; }

    }
}
