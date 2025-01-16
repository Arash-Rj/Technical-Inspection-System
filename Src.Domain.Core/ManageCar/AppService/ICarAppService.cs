using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageCar.Enums;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageCar.AppService
{
    public interface ICarAppService
    {
        public List<ModelEnum> GetCarModels();
        public Result CanRequest(Car car);
    }
}
