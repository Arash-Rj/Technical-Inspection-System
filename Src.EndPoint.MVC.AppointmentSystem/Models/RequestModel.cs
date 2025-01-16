using Src.Domain.Core.ManageCar.Enums;

namespace Src.EndPoint.MVC.AppointmentSystem.Models
{
    public class RequestModel
    {
        public string UserName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ModelEnum CarModel { get; set; }
        public CompanyEnum CarCompany { get; set; }
        public string LicensePlate { get; set; }
    }
}
