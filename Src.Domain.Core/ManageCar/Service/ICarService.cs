using Src.Domain.Core.ManageCar.Entities;
using Src.Domain.Core.ManageCar.Enums;
using Src.Domain.Core.ManageUser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.ManageCar.Service
{
    public interface ICarService
    {
        public List<ModelEnum> GetCarModels();
        public Car? GetCarByLicense(string carlicense);
        public Result EvenOrOdd(CompanyEnum company);
        public Result IsOld(DateOnly manufactureDate);
        public int GetCarId(string LicensePlate);
    }
}
