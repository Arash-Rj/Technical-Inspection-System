using Src.Domain.Core.ManageUser.Entities;

namespace Src.EndPoint.MVC.AppointmentSystem.Models
{
    public class OnlineAdminModel
    {
        public static User? User;
        public OnlineAdminModel(User user)
        {
            User = user;
        }
    }
}
