using Src.Domain.Core.ManageCar.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageCar.Entities
{
    public class Cardto
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public CompanyEnum Company { get; set; }
        public ModelEnum Model { get; set; }
        public Cardto() { }
    }
}
