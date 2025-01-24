using Src.Domain.Core.ManageCar.Enums;
using System.ComponentModel.DataAnnotations;

namespace Src.EndPoint.MVC.AppointmentSystem.Models
{
    public class RequestModel
    {
        [Display(Name = "نام مالک خودرو")]
        [Required(ErrorMessage ="Username is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "NationalCode is required.")]
        [StringLength(11, ErrorMessage = "National code can not be more than 10 numbers.")]
        public string NationalCode { get; set; }
        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^(\+98|0)?9\d{9}$",ErrorMessage ="Enter a valid phone number(+98 or 09)")]
        public string PhoneNumber { get; set; }
        [StringLength(50,ErrorMessage ="Address can not be more than 50 characters.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "CarModel is required.")]
        public ModelEnum CarModel { get; set; }
        [Required(ErrorMessage = "Company is required.")]
        public CompanyEnum CarCompany { get; set; }
        [Required(ErrorMessage = "LicensePlate is required.")]
        public string LicensePlate { get; set; }
        [Required(ErrorMessage ="Request date is required.")]
        [DataType(DataType.DateTime,ErrorMessage ="Date format is wrong.")]
        [CustomValidation(typeof(RequestModel),nameof(DateValidation))]
        public DateTime RequestDate { get; set; }
        public static ValidationResult DateValidation(DateTime date,ValidationContext context)
        {
            if(date < DateTime.Now)
            {
                return new ValidationResult( "Date can not be before today.");
            }
            else
            { 
                return ValidationResult.Success;
            }
        }
    }
}
