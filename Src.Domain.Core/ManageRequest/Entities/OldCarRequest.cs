using Src.Domain.Core.ManageCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageRequest.Entities
{
    public class OldCarRequest
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public DateTime LogDate { get; set; }
        public OldCarRequest()
        {
            LogDate = DateTime.Now;
        }
    }
}
